using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TPProject.Domain.Entities;

namespace TPProject.Infrastructure.Persistence.Configurations;
public class BrandConfiguration : IEntityTypeConfiguration<Brand>
{
    public void Configure(EntityTypeBuilder<Brand> builder)
    {
        builder.Property(t => t.BarandName)
            .HasMaxLength(200)
            .IsRequired();
    }
}
