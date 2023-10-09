using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectTracker.Models;

namespace ProjectTracker.Data.Map
{
    public class LogProcessoMap : IEntityTypeConfiguration<LogProcesso>
    {
        public void Configure(EntityTypeBuilder<LogProcesso> builder)
        {
            //builder.HasKey(x => new {x.IdEmpresa, x.IdProcesso, x.IdUsuario});
            //builder.HasOne(x => x.Empresa).WithMany(d => d.LogProcessos).HasForeignKey(x => x.IdEmpresa);
            //builder.HasOne(x => x.Usuario).WithMany(d => d.LogProcessos).HasForeignKey(x => x.IdUsuario);
            //builder.HasOne(X => X.Processo).WithMany(d => d.LogProcessos).HasForeignKey(x => x.IdProcesso);

            builder.HasKey(x => x.Id);
            builder.HasOne(x=> x.ProcessoUsuario).WithMany(d=> d.LogsProcessos).HasForeignKey(f=> f.IdProcessoUsuario);

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
