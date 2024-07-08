using System.ComponentModel.DataAnnotations;

namespace Biblioteca.Models
{
    public class Emprestimo
    {
        [Key]
        public int Id { get; set; }
        public int LivroId { get; set; }
        public Livro Livro { get; set; } = null!;
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; } = null!;
        public string DataEmprestimo { get; set; } = null!;
        public string DataDevolucao { get; set; } = null!;
    }
}
