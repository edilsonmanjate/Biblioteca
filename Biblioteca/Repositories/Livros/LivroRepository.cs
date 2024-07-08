using Biblioteca.Data;
using Biblioteca.Models;

using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Repositories.Livros
{
    public class LivroRepository : ILivroRepository
    {
        private readonly ApplicationDbContext _context;
        public LivroRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Livro livro)
        {
            await _context.Livros.AddAsync(livro);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteByIdAsync(int id)
        {
            var livro = await GetByIdAsync(id);
            if(livro != null)
            {
                _context.Livros.Remove(livro);  
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Livro>> GetAllAsync()
        {
            return await _context
                        .Livros
                        .AsNoTracking()
                        .ToListAsync();
        }

        public async Task<Livro?> GetByIdAsync(int id)
        {
            return await _context.Livros.SingleOrDefaultAsync(l=>l.Id==id);
        }

        public async Task UpdateAsync(Livro livro)
        {
            _context.Livros.Update(livro);
            await _context.SaveChangesAsync();
        }
    }
}
