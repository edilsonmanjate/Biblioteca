using Biblioteca.Models;
using Biblioteca.Repositories.Emprestimos;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

using MudBlazor;

namespace Biblioteca.Components.Pages.Emprestimos
{
    public class IndexPage : ComponentBase
    {
        [Inject]
        public IEmprestimoRepository repository { get; set; } = null!;

        [Inject]
        IDialogService Dialog { get; set; } = null!;

        [Inject]
        public ISnackbar Snackbar { get; set; } = null!;

        [Inject]
        public NavigationManager NavigationManager { get; set; } = null!;

        public List<Emprestimo> Emprestimos { get; set; } = new();

        //public bool HideButtons { get; set; }
        //[CascadingParameter]
        //private Task<AuthenticationState> AuthenticationStateTask { get; set; }

        public void GoToUpdate(int agendamentoId)
        {
            NavigationManager.NavigateTo($"/emprestimos/update/{agendamentoId}");
        }

        public async Task DeleteEmprestimo(Emprestimo agendamento)
        {
            try
            {
                var result = await Dialog.ShowMessageBox
                (
                "Atenção"
                , $"Tem a certeza que quer apagar o emprestimo {agendamento.Id}?"
                , yesText: "Sim",
                cancelText: "Não"
                );

                if (result is true)
                {
                    await repository.DeleteAsync(agendamento.Id);
                    Snackbar.Add($"Emprestimo {agendamento.Id} apagado, e nunca mais será recuperado.", Severity.Success);
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
            //var auth = await AuthenticationStateTask;
            //HideButtons = !auth.User.IsInRole("Atendente");
            Emprestimos = await repository.GetAllAsync();
        }

    }
}
