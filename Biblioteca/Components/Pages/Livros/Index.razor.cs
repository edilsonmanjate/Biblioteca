using Biblioteca.Models;
using Biblioteca.Repositories.Livros;

using Microsoft.AspNetCore.Components;

using MudBlazor;

namespace Biblioteca.Components.Pages.Livros
{
    public class IndexPage : ComponentBase
    {
        [Inject]
        public ILivroRepository repository { get; set; } = null!;
        [Inject]
        IDialogService Dialog { get; set; } = null!;

        [Inject]
        public ISnackbar Snackbar { get; set; } = null!;

        [Inject]
        public NavigationManager NavigationManager { get; set; } = null!;

        public List<Livro> Livros { get; set; } = new List<Livro>();
        public LivroInputModel Livro { get; set; } = new LivroInputModel();

        public void GoToUpdate(int livroId)
        {
            NavigationManager.NavigateTo($"/livros/update/{livroId}");
        }

        public async Task DeleteLivro(Livro livros)
        {
            try
            {
                var result = await Dialog.ShowMessageBox
                (
                "Atenção"
                , $"Tem a certeza que quer apagar o livro {livros.Titulo}?"
                , yesText: "Sim",
                cancelText: "Não"
                );

                if (result is true)
                {
                    await repository.DeleteByIdAsync(livros.Id);
                    Snackbar.Add($"Paciente {livros.Titulo} apagado, e nunca mais será recuperado.", Severity.Success);
                    await OnInitializedAsync();
                }
            }
            catch (Exception ex)
            {
                Snackbar.Add(ex.Message, Severity.Error);
            }
        }

        protected override async Task OnInitializedAsync()
        {
           // var auth = await AuthenticationStateTask;
           // HideButtons = !auth.User.IsInRole("Atendente");
            Livros = await repository.GetAllAsync();
        }

    }
}
