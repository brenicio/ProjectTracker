using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectTracker.Models;

namespace ProjectTracker.Data.Map
{
    public class AreaMap : IEntityTypeConfiguration<Area>
    {
        public void Configure(EntityTypeBuilder<Area> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasMany(x => x.UsrAreas).WithOne(d => d.Area).HasForeignKey(f => f.IdArea);
           //builder.HasOne(x => x.Processo).WithMany(d => d.Areas).HasForeignKey(f => f.IdProcesso);

            builder.Property(x => x.Nome)
                .HasMaxLength(150)
                .HasColumnType("varchar")
                .IsRequired();
            
        }
    }
}
