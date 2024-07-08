using Biblioteca.Models;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

using System.Reflection.Emit;

namespace Biblioteca.Data
{
    public class DbInitializer
    {
        private readonly ModelBuilder _modelBuilder;

        public DbInitializer(ModelBuilder modelBuilder)
        {
            _modelBuilder = modelBuilder;
        }
        internal void Seed()
        {
            _modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole { Id = "1", Name = "Admin", NormalizedName = "ADMIN" },
                new IdentityRole { Id = "2", Name = "Uilizador", NormalizedName = "Utilizador" }
            );

            var hasher = new PasswordHasher<IdentityUser>();
            _modelBuilder.Entity<Usuario>().HasData(
                new Usuario
                {
                    Id = "1",
                    Nome = "Administrador",
                    Email = "admin@mail.com",
                    UserName = "admin@mail.com",
                    EmailConfirmed = true,
                    NormalizedEmail = "ADMIN@MAIL.COM",
                    NormalizedUserName = "ADMIN@MAIL.COM",
                    PasswordHash = hasher.HashPassword(null, "Administrator@123"),
                },

                 new Usuario
                 {
                     Id = "2",
                     Nome = "Edilson",
                     Email = "edilson@mail.com",
                     UserName = "edilson@mail.com",
                     EmailConfirmed = true,
                     NormalizedEmail = "EDILSON@MAIL.COM",
                     NormalizedUserName = "EDILSON@MAIL.COM",
                     PasswordHash = hasher.HashPassword(null, "Administrator@123"),
                 });

            _modelBuilder.Entity<IdentityUserRole<String>>().HasData(
                new IdentityUserRole<string> { UserId = "1", RoleId = "1" },
                new IdentityUserRole<string> { UserId = "2", RoleId = "2" }

             );

            _modelBuilder.Entity<Livro>().HasData(
                new Livro
                {
                    Id = 1,
                    Titulo = "O Senhor dos Anéis",
                    Autor = "J.R.R. Tolkien",
                    Ano = 1954,
                    ISBN = "9780345339706"
                },
                new Livro
                {
                    Id = 2,
                    Titulo = "O Código Da Vinci",
                    Autor = "Dan Brown",
                    Ano = 2003,
                    ISBN = "9780552149518"
                },
                new Livro
                {
                    Id = 3,
                    Titulo = "O Pequeno Príncipe",
                    Autor = "Antoine de Saint-Exupéry",
                    Ano = 1943,
                    ISBN = "9788572329864"
                },
                new Livro
                {
                    Id = 4,
                    Titulo = "Dom Quixote",
                    Autor = "Miguel de Cervantes",
                    Ano = 1605,
                    ISBN = "9789726081533"
                },
                new Livro
                {
                    Id = 5,
                    Titulo = "O Hobbit",
                    Autor = "J.R.R. Tolkien",
                    Ano = 1937,
                    ISBN = "9780345339683"
                },
                new Livro
                {
                    Id = 6,
                    Titulo = "Harry Potter e a Pedra Filosofal",
                    Autor = "J.K. Rowling",
                    Ano = 1997,
                    ISBN = "9780747532743"
                },
                    new Livro
                    {
                    Id = 7,
                    Titulo = "O Alquimista",
                    Autor = "Paulo Coelho",
                    Ano = 1988,
                    ISBN = "9780062315007"
                },
                    new Livro
                    {
                    Id = 8,
                    Titulo = "O Diário de Anne Frank",
                    Autor = "Anne Frank",
                    Ano = 1947,
                    ISBN = "9788587220851"
                });

        }
    }
}
