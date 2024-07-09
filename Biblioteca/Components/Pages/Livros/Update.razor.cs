using Biblioteca.Models;
using Biblioteca.Repositories.Livros;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

using MudBlazor;

using static MudBlazor.CategoryTypes;


namespace Biblioteca.Components.Pages.Livros
{
    public class UpdateLivroPage : Microsoft.AspNetCore.Components.ComponentBase
    {
        [Parameter]
        public int LivroId { get; set; }

        [Inject]
        public ILivroRepository repository { get; set; } = null!;

        [Inject]
        IDialogService Dialog { get; set; } = null!;

        [Inject]
        public ISnackbar Snackbar { get; set; } = null!;

        [Inject]
        public NavigationManager NavigationManager { get; set; } = null!;

        public LivroInputModel InputModel { get; set; } = new();

        private Livro? CurrentLivro;
        public int MaxYear { get; set; } = DateTime.Now.Year;

        protected override async Task OnInitializedAsync()
        {
            CurrentLivro = await repository.GetByIdAsync(LivroId);
            if (CurrentLivro is null)
                return;

            InputModel = new LivroInputModel
            {
                Id = CurrentLivro.Id,
                Titulo = CurrentLivro.Titulo,
                Autor = CurrentLivro.Autor,
                Ano = CurrentLivro.Ano,
                ISBN = CurrentLivro.ISBN,

            };
        }


        public async void Cancelar()
        {
            var result = await  Dialog.ShowMessageBox
               (
               "Atenção"
               , $"Tem a certeza que quer cancelar as alterações feitas?"
               , yesText: "Sim",
               cancelText: "Não"
               );

            if (result is true)
            {
                NavigationManager.NavigateTo("/livros");
            }
            
        }
        public async Task OnValidSubmitAsync(EditContext editContext)
        {
            try
            {
                if (editContext.Model is LivroInputModel model)
                {
                    CurrentLivro.Titulo = model.Titulo;
                    CurrentLivro.Autor = model.Autor;
                    CurrentLivro.Ano = model.Ano;
                    CurrentLivro.ISBN = model.ISBN;

                    await repository.UpdateAsync(CurrentLivro);

                    Snackbar.Add("Livro actualizado com sucesso", Severity.Success);
                    NavigationManager.NavigateTo("/livros");

                }
            }
            catch (Exception ex)
            {
                Snackbar.Add(ex.Message, Severity.Error);
            }
        }

    }
}