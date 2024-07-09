using System.ComponentModel.DataAnnotations;

namespace Biblioteca.Components.Pages.Livros
{
    public class LivroInputModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo Título é obrigatório")]
        [MaxLength(60, ErrorMessage = "O campo Título deve ter no máximo 50 caracteres")]
        public string Titulo { get; set; } = null!;
        [Required(ErrorMessage = "O campo Autor é obrigatório")]
        [MaxLength(60, ErrorMessage = "O campo Autor deve ter no máximo 50 caracteres")]
        public string Autor { get; set; } = null!;

        [Required(ErrorMessage = "O campo Ano é obrigatório")]
        public int Ano { get; set; }

        [Required(ErrorMessage = "O campo Ano é obrigatório")]
        public string ISBN { get; set; } = null!;
    }
}
