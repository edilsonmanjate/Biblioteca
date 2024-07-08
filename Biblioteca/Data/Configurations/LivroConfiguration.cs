using Biblioteca.Models;

using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Data.Configurations
{
    public class LivroConfiguration : IEntityTypeConfiguration<Livro>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Livro> builder)
        {
            builder.ToTable("Livros");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Titulo)
                    .IsRequired()
                    .HasColumnType("varchar(60)");

            builder.Property(p => p.Autor)
                    .IsRequired()
                    .HasColumnType("nvarchar(60)");

            builder.Property(l => l.Ano)
                        .IsRequired()
                        .HasColumnType("nvarchar(13)");

            builder.Property(p => p.ISBN)
                      .IsRequired();

            builder.HasIndex(p => p.ISBN)
                    .IsUnique();

            builder.HasMany(a => a.Emprestimos)
                    .WithOne(p => p.Livro)
                    .HasForeignKey(a => a.LivroId)
                    .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
