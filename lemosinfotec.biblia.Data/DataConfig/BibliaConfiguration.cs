using lemosinfotec.biblia.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace lemosinfotec.biblia.Data.DataConfig
{
    public class BibliaConfiguration : IEntityTypeConfiguration<Biblia>
    {
        public void Configure(EntityTypeBuilder<Biblia> builder)
        {
            builder.ToTable("Biblia");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Titulo)
                .HasMaxLength(60)
               .HasColumnType("varchar")
               .IsRequired();

            builder.Property(p => p.Versiculo)
                .HasColumnType("int")
                .IsRequired();

            builder.Property(p => p.Capitulo)
               .HasMaxLength(50)
               .HasColumnType("int")
               .IsRequired();

            builder.Property(p => p.Conteudo)
               .HasMaxLength(1000)
               .HasColumnType("varchar")
               .IsRequired();
        }
    }
}
