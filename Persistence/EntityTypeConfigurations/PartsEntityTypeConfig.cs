using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityTypeConfigurations;

public class PartsEntityTypeConfig : IEntityTypeConfiguration<Part>
{
    public void Configure(EntityTypeBuilder<Part> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Partnumber);

        builder.HasOne(x => x.Car)
            .WithMany(x => x.Parts)
            .HasForeignKey(x => x.Id);
    }
}