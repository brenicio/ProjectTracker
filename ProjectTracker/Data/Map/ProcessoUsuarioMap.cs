using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectTracker.Models;

namespace ProjectTracker.Data.Map
{
    public class ProcessoUsuarioMap : IEntityTypeConfiguration<ProcessoUsuario>
    {
        public void Configure(EntityTypeBuilder<ProcessoUsuario> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Empresa).WithMany(d => d.ProcessosUsuario).HasForeignKey(x => x.IdEmpresa);
            builder.HasOne(x => x.Usuario).WithMany(d => d.ProcessosUsuario).HasForeignKey(x => x.IdUsuario);
            builder.HasOne(X => X.Processo).WithMany(d => d.ProcessosUsuario).HasForeignKey(x => x.IdProcesso);


            builder.Property(x => x.Status)
                .HasMaxLength(12)
                .HasColumnType("varchar")
                .IsRequired();

            builder.Property(x => x.TempoDecorrido)
                .HasColumnType("bigint")
                .IsRequired(false);

            //builder.Property(x => x.TempoDecorrido)
            //    .HasConversion(
            //        v => v.HasValue ? (long?)v.Value.TotalSeconds : null,
            //        v => v.HasValue ? (TimeSpan?)TimeSpan.FromSeconds(v.Value) : null)
            //    .HasColumnType("bigint")
            //    .IsRequired(false);
        }
    }
}
