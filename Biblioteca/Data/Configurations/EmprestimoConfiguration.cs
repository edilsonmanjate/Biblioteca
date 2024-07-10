using Biblioteca.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using System.Reflection.Emit;

namespace Biblioteca.Data.Configurations
{
    public class EmprestimoConfiguration: IEntityTypeConfiguration<Emprestimo>
    {
        public void Configure(EntityTypeBuilder<Emprestimo> builder)
        {
            builder.ToTable("Emprestimos");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.DataEmprestimo)
                    .IsRequired()
                    .HasColumnType("date");

            builder.Property(p => p.DataDevolucao)
                    .IsRequired()
                    .HasColumnType("date");

            //builder.Property(p => p.UsuarioId)
            //        .IsRequired();

            builder.Property(p => p.LivroId)
            .IsRequired();

            builder.HasOne(e => e.Usuario)
                    .WithMany()
                    .HasForeignKey(e => e.UsuarioId)
                    .IsRequired();

        }
    }
}

