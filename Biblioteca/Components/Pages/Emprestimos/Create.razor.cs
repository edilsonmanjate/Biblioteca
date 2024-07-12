
using Biblioteca.Data;
using Biblioteca.Models;
using Biblioteca.Repositories.Emprestimos;
using Biblioteca.Repositories.Livros;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Identity;

using MudBlazor;


namespace Biblioteca.Components.Pages.Emprestimos
{
    public class CreateEmprestimoPage : ComponentBase
    {
        [Inject]
        private IEmprestimoRepository repository { get; set; } = null!;

        [Inject]
        private ILivroRepository livroRepository { get; set; } = null!;

        [Inject]
        private ISnackbar Snackbar { get; set; } = null!;

        [Inject]
        private IDialogService Dialog { get; set; } = null!;

        [Inject]
        private UserManager<ApplicationUser> _userManager { get; set; } = null!;

        [Inject]
        private IHttpContextAccessor _httpContextAccessor { get; set; } = null!;

        protected EmprestimoInputModel InputModel { get; set; } = new EmprestimoInputModel();

        public List<Livro> Livros { get; set; } = new();

        [Inject]
        protected NavigationManager NavigationManager { get; set; } = null!;

        public string NomeUser;
        public string IdUser;

        public DateTime? date { get; set; } = DateTime.Now.Date;
        public DateTime? MinDate { get; set; } = DateTime.Now.Date;


        public async Task OnValidSubmitAsync(EditContext editContext)
        {
            try
            {
                if (editContext.Model is EmprestimoInputModel model)
                {
                    var emprestimo = new Emprestimo
                    {
                        DataEmprestimo = date!.Value,
                        DataDevolucao = date!.Value.AddDays(7),
                        LivroId = model.LivroId,
                        UsuarioId = IdUser
                    };

                    await repository.AddAsync(emprestimo);
                    Snackbar.Add("Emprestimo registado com sucesso", Severity.Success);
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
               , $"Tem a certeza que quer cancelar?"
               , yesText: "Sim",
               cancelText: "Não"
               );

            if (result is true)
            {
                NavigationManager.NavigateTo("/emprestimos");
            }

        }


        protected override async Task OnInitializedAsync()
        {
            Livros = await livroRepository.GetAllAsync();
            var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
            if (user != null)
            {
                NomeUser = user.UserName;
                IdUser = user.Id;
                // Aqui você pode acessar as propriedades do usuário, como user.Email, user.UserName, etc.
                // E preencher os campos do formulário conforme necessário.
            }
        }

    }
}