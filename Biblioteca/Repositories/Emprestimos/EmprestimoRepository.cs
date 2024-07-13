using Biblioteca.Data;
using Biblioteca.Models;

using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Repositories.Emprestimos
{
    public class EmprestimoRepository : IEmprestimoRepository
    {
        private readonly ApplicationDbContext _context;

        public EmprestimoRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<List<Emprestimo>> GetByUserIdAsync(string userId)
        {
            return await _context.Emprestimos
                                 .Where(e => e.UsuarioId == userId) // Filtra pelo ID do usuário
                                 .Include(e => e.Livro)
                                 .Include(p => p.Usuario)
                                 .AsNoTracking()
                                 .ToListAsync();
        }


        public async Task<List<Emprestimo>> GetAllAsync()
        {
            return await _context
                        .Emprestimos
                        .Include(e => e.Livro)
                        .Include(p => p.Usuario)
                        .AsNoTracking()
                        .ToListAsync();
        }

        public async Task<Emprestimo?> GetByIdAsync(int id)
        {
            return await _context.Emprestimos.SingleOrDefaultAsync(e => e.Id == id);
        }

        public async Task AddAsync(Emprestimo emprestimo)
        {
            _context.Emprestimos.Add(emprestimo);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Emprestimo emprestimo)
        {
            _context.Emprestimos.Update(emprestimo);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var emprestimo = await GetByIdAsync(id);
            if (emprestimo != null)
            {
                _context.Emprestimos.Remove(emprestimo);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<EmprestimosAnuais>?> GetReportAsync(string userId)
        {
            var result = _context.Database.SqlQuery<EmprestimosAnuais>($"SELECT MONTH(DataEmprestimo) AS Mes, COUNT(*) AS QuantidadeAgendamentos FROM Emprestimos WHERE YEAR(DataEmprestimo) = year(GETDATE())  GROUP BY MONTH(DataEmprestimo) ORDER BY Mes;");
            return await Task.FromResult(result.ToList());
        }   
    }
}
