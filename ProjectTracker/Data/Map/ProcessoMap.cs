using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectTracker.Models;

namespace ProjectTracker.Data.Map
{
    public class ProcessoMap : IEntityTypeConfiguration<Processo>
    {
        public void Configure(EntityTypeBuilder<Processo> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Area).WithMany(d => d.Processos).HasForeignKey(f => f.IdArea);
        }
    }
}
