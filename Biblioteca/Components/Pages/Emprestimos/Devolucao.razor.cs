using Biblioteca.Models;
using Biblioteca.Repositories.Emprestimos;
using Biblioteca.Repositories.Livros;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

using MudBlazor;

using static MudBlazor.CategoryTypes;

namespace Biblioteca.Components.Pages.Emprestimos
{
    public class DevolucaoLivroPage : Microsoft.AspNetCore.Components.ComponentBase
    {
        [Parameter]
        public int EmprestimoId { get; set; }

        [Inject]
        public IEmprestimoRepository repository { get; set; } = default!;

        [Inject]
        public ILivroRepository livroRepository { get; set; } = default!;

        [Inject]
        IDialogService Dialog { get; set; } = null!;

        [Inject]
        public ISnackbar Snackbar { get; set; } = null!;



        [Inject]
        public NavigationManager NavigationManager { get; set; } = null!;

        public Emprestimo? CurrentEmprestimo { get; set; }
        public string TituloLivro;

        public EmprestimoInputModel InputModel { get; set; } = new();

        protected override async Task OnInitializedAsync()
        {
            CurrentEmprestimo = await repository.GetByIdAsync(EmprestimoId);
            var LivroEmprestado = await livroRepository.GetByIdAsync(CurrentEmprestimo.LivroId);
            TituloLivro = LivroEmprestado.Titulo;

            if (CurrentEmprestimo is null) return;

            InputModel = new EmprestimoInputModel
            {
                LivroId = CurrentEmprestimo.LivroId,
                DataEmprestimo = CurrentEmprestimo.DataEmprestimo,
                Devolvido = CurrentEmprestimo?.Devolvido ?? false,
                DataDevolucao = CurrentEmprestimo.DataDevolucao,
                UsuarioId = CurrentEmprestimo.UsuarioId

            };
        }

        public async Task OnValidSubmitAsync(EditContext editContext)
        {
            try
            {
                if (CurrentEmprestimo is null) return;

                if (editContext.Model is EmprestimoInputModel model)
                {
                    CurrentEmprestimo.Id = EmprestimoId;
                    CurrentEmprestimo.LivroId = model.LivroId;
                    CurrentEmprestimo.DataEmprestimo = model.DataEmprestimo;
                    CurrentEmprestimo.DataDevolucao = model.DataDevolucao;
                    CurrentEmprestimo.Devolvido = model?.Devolvido ?? false;

                    await repository.UpdateAsync(CurrentEmprestimo);
                    Snackbar.Add("Livro devolvido com sucesso!", Severity.Success);
                    NavigationManager.NavigateTo("/emprestimos");
                }
            }
            catch (Exception ex)
            {
                Snackbar.Add(ex.Message, Severity.Error);
            }
        }

        public async void Cancelar()
        {
            var result = await Dialog.ShowMessageBox
               (
               "Atenção"
               , $"Tem a certeza que quer cancelar a introdução?"
               , yesText: "Sim",
               cancelText: "Não"
               );

            if (result is true)
            {
                NavigationManager.NavigateTo("/livros");
            }

        }

     
    }
}
