using Biblioteca.Models;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using System.Reflection;

namespace Biblioteca.Data
{

    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
       : IdentityDbContext<ApplicationUser>(options)
    {
        public DbSet<Livro> Livros { get; set; }
        public DbSet<Emprestimo> Emprestimos { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            new DbInitializer(builder).Seed();
            base.OnModelCreating(builder); builder.Entity<Livro>();
        }

    }
}
