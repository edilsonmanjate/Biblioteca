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

        public async Task<List<Emprestimo>> GetReportAsync()
        {
            return await _context.Emprestimos
                .Include(e => e.Livro)
                //.Include(e => e.Usuario)
                .ToListAsync();
        }   
    }
}
