using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectTracker.Models;

namespace ProjectTracker.Data.Map
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasMany(x => x.UsrAreas).WithOne(d => d.Usuario).HasForeignKey(f => f.IdUsuario);

            builder.Property(x => x.Nome)
                .HasMaxLength(150)
                .HasColumnType("varchar")
                .IsRequired();

            builder.Property(x => x.Senha)
                .HasMaxLength(15)
                .HasColumnType("varchar")
                .IsRequired();

            builder.Property(x => x.Login)
                .HasMaxLength(50)
                .HasColumnType("varchar")
                .IsRequired();

            builder.Property(x => x.Tipo)
                .HasMaxLength(15)
                .HasColumnType("varchar");
        }
    }
}
