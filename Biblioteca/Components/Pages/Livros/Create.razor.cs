using Biblioteca.Models;
using Biblioteca.Repositories.Livros;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

using MudBlazor;

namespace Biblioteca.Components.Pages.Livros
{
    public class CreateLivroPage : ComponentBase
    {
        [Inject]
        public ILivroRepository repository { get; set; } = null!;

        [Inject]
        IDialogService Dialog { get; set; } = null!;

        [Inject]
        public ISnackbar Snackbar { get; set; } = null!;

        [Inject]
        public NavigationManager NavigationManager { get; set; } = null!;

        public LivroInputModel InputModel { get; set; } = new LivroInputModel();

        public int MaxYear { get; set; } = DateTime.Now.Year;




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

        public async Task OnValidSubmitAsync(EditContext editContext)
        {
            try
            {
                if (editContext.Model is LivroInputModel model)
                {
                    var livro = new Livro
                    {
                        Titulo = model.Titulo,
                        Autor = model.Autor,
                        Ano = model.Ano,
                        ISBN = model.ISBN,
                    };
                    await repository.AddAsync(livro);
                    Snackbar.Add("Livro criado com sucesso", Severity.Success);
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
