using ClaimsAutoProcessing.Api.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClaimsAutoProcessing.Api.Infrastructure.Persistence.Configurations;

public class BatchConfiguration : IEntityTypeConfiguration<Batch>
{
    public void Configure(EntityTypeBuilder<Batch> builder)
    {
        builder.ToTable("Batch");

        builder.Property(e => e.Id);
        builder.Property(e => e.CreatedAt);
        builder.Property(e => e.HealthcareFacilityCode);
        builder.Property(e => e.CreatedAt);

        builder
            .HasMany(b => b.Claims)
            .WithOne();
    }
}