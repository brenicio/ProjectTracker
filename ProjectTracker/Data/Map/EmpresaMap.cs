using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectTracker.Models;

namespace ProjectTracker.Data.Map
{
    public class EmpresaMap : IEntityTypeConfiguration<Empresa>
    {
        public void Configure(EntityTypeBuilder<Empresa> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Uf)
                .HasMaxLength(2)
                .HasColumnType("varchar");

            builder.Property(x => x.Nome)
                .HasMaxLength(150)
                .HasColumnType("varchar")
                .IsRequired();
            
            builder.Property(x => x.Lotes)
                .HasColumnType("integer");

            builder.Property(x => x.AreaTotal)
                .HasColumnType("decimal(18,2)");

            builder.Property(x => x.Cidade)
                .HasMaxLength(25)
                .HasColumnType("varchar");

            builder.Property(x => x.Observacao)
                .HasColumnType("nvarchar(max)");

        }
    }
}
