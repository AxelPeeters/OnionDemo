using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence;

public class CarEntityTypeConfig : IEntityTypeConfiguration<Car>
{
    public void Configure(EntityTypeBuilder<Car> builder)
    {
        builder.HasKey(x => x.Id);
        
        builder.HasMany(x => x.Parts)
            .WithOne(x => x.Car)
            .HasForeignKey(x => x.Id);
    }
}