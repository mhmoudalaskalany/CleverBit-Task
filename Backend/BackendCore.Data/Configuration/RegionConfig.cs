using BackendCore.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BackendCore.Data.Configuration
{
    public class RegionConfig : IEntityTypeConfiguration<Region>
    {
        public void Configure(EntityTypeBuilder<Region> builder)
        {
            builder.Property(e => e.Id)
                .ValueGeneratedNever();

            //builder.HasMany(e => e.ChildRegions)
            //    .WithOne(p => p.ParentRegion)
            //    .HasForeignKey(p => p.ParentRegionId)
            //    .OnDelete(DeleteBehavior.NoAction);
        }
    }
}