using System.ComponentModel.DataAnnotations;

namespace Biblioteca.Models
{
    public class Livro
    {
        [Key]
        public int Id { get; set; }
        public string Titulo { get; set; } = null!;
        public string Autor { get; set; } = null!;
        public int Ano { get; set; }
        public string ISBN { get; set; } = null!;
        public ICollection<Emprestimo> Emprestimos { get; set; } = new List<Emprestimo>();

    }
}
