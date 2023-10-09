using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectTracker.Models;

namespace ProjectTracker.Data.Map
{
    public class LogAreaMap : IEntityTypeConfiguration<LogArea>

    {
        public void Configure(EntityTypeBuilder<LogArea> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Empresa).WithMany(d => d.LogAreas).HasForeignKey(f => f.IdEmpresa);
            builder.HasOne(x => x.Area).WithMany(d => d.LogAreas).HasForeignKey(f => f.IdArea);

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
