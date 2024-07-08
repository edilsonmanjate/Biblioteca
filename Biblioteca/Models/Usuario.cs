using Biblioteca.Data;

namespace Biblioteca.Models
{
    public class Usuario : ApplicationUser
    {
        public string Nome { get; set; } = null!;
    }
}
