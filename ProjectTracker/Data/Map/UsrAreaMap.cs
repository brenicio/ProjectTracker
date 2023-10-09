using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectTracker.Models;

namespace ProjectTracker.Data.Map
{
    public class UsrAreaMap : IEntityTypeConfiguration<UsrArea>
    {
        public void Configure(EntityTypeBuilder<UsrArea> builder)
        {
            builder.HasKey(x => new { x.IdArea, x.IdUsuario });
            builder.HasOne(x => x.Area).WithMany(d => d.UsrAreas).HasForeignKey(f => f.IdArea);
            builder.HasOne(x => x.Usuario).WithMany(d => d.UsrAreas).HasForeignKey(f => f.IdUsuario);
        }
    }
}
