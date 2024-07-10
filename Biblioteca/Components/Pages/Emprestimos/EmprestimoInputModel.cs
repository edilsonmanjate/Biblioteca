using Biblioteca.Models;

using System.ComponentModel.DataAnnotations;

namespace Biblioteca.Components.Pages.Emprestimos
{
    public class EmprestimoInputModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo livro é obrigatório")]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Valor inválido")]
        public int LivroId { get; set; }

        [Required(ErrorMessage = "O campo utilizador é obrigatório")]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Valor inválido")]
        public string UsuarioId { get; set; }

        [Required(ErrorMessage = "O campo Data de empréstimo é obrigatório")]
        public DateTime DataEmprestimo { get; set; }
        [Required(ErrorMessage = "O campo Data de devolução é obrigatório")]
        public DateTime DataDevolucao { get; set; }
    }
}
