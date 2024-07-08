using Biblioteca.Models;

namespace Biblioteca.Repositories.Livros
{
    public interface ILivroRepository
    {
        Task AddAsync(Livro livro);
        Task UpdateAsync(Livro livro);
        Task<Livro?> GetByIdAsync(int id);
        Task<List<Livro>> GetAllAsync();
        Task DeleteByIdAsync(int id);
    }
}
