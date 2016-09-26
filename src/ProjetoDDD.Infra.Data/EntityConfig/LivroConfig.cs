using System.Data.Entity.ModelConfiguration;
using ProjetoDDD.Domain.Entities;

namespace ProjetoDDD.Infra.Data.EntityConfig
{
    public class LivroConfig : EntityTypeConfiguration<Livro>
    {
        public LivroConfig()
        {
            HasKey(e => e.LivroId);

            Property(e => e.AnoLetivo)
                .IsRequired()
                .HasMaxLength(10);

            Property(e => e.Autor)
                .IsRequired()
                .HasMaxLength(100);

            Property(e => e.Disciplina)
                .IsRequired()
                .HasMaxLength(50);

            Property(e => e.Titulo)
                .IsRequired()
                .HasMaxLength(50);

            //HasOptional()
            HasRequired(e => e.Cliente)
                .WithMany(c => c.Livros)
                .HasForeignKey(e => e.ClienteId);

            ToTable("Livros");
        }
    }
}