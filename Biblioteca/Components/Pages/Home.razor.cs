using Biblioteca.Data;
using Biblioteca.Models;
using Biblioteca.Repositories.Emprestimos;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;

using MudBlazor;
using System.Globalization; 

namespace Biblioteca.Components.Pages
{
    public class HomePage : ComponentBase
    {
        [Inject]
        private IEmprestimoRepository repository { get; set; }

        [Inject]
        private UserManager<ApplicationUser> _userManager { get; set; } = null!;

        [Inject]
        private IHttpContextAccessor _httpContextAccessor { get; set; } = null!;

        [CascadingParameter]
        private Task<AuthenticationState> AuthenticationStateTask { get; set; }

        public ChartOptions Options = new ChartOptions
        {
            LineStrokeWidth = 20,
            YAxisTicks = 1
        };
        public String[] XAxisLabels { get; set; } = [];
        public List<ChartSeries> Series { get; set; } = new();

        public double[] data { get; set; } = [];
        public string[] labels { get; set; } = [];

        protected override async Task OnInitializedAsync()
        {
            var auth = await AuthenticationStateTask;
            //HideButtons = !auth.User.IsInRole("Atendente");

            var userId = _userManager.GetUserId(auth.User); // Obter o ID do usuário logado
            var result = await repository.GetReportAsync(userId);

            if (result is null || !result.Any())
                return;

            MontaGraficoBarra(result);
            MontaGraficoTorta(result);
        }

        private void MontaGraficoBarra(List<EmprestimosAnuais> emprestimos)
        {
            XAxisLabels = emprestimos
                            .Select(x => CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(x.Mes)).ToArray();

            var serie = new ChartSeries
            {
                Name = "Emprestimos Mensais",
                Data = emprestimos.Select(x => (double)x.QuantidadeAgendamentos).ToArray()
            };

            Series.Add(serie);
        }

        private void MontaGraficoTorta(List<EmprestimosAnuais> emprestimos)
        {
            labels = emprestimos
                        .Select(x => CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(x.Mes)).ToArray();

            data = emprestimos.Select(x => (double)x.QuantidadeAgendamentos).ToArray();
        }
    }
}
