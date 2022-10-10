using ClaimsSubmission.Domain.AggregateModels.BatchFileAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClaimsSubmission.Infrastructure.Persistence.Configurations;

public class BatchFileValidationResultConfiguration : IEntityTypeConfiguration<BatchFileValidationResult>
{
    public void Configure(EntityTypeBuilder<BatchFileValidationResult> builder)
    {
        builder.ToTable("BatchFileValidationResult");

        builder.Ignore(e => e.Events);

        builder.Property(e => e.Id);

        builder.Property(e => e.Id)
            .HasColumnName("Id")
            .HasMaxLength(Guid.NewGuid().ToString().Length)
            .HasConversion(id => id.Value, id => new BatchFileValidationResultId(id));

        builder.Property("_claimsTotalCount")
            .HasColumnName("ClaimsTotalCount");

        builder.Property("_claimsValidCount")
            .HasColumnName("ClaimsValidCount");

        builder.Property("_createdAt")
            .HasColumnName("CreatedAt");

        builder
            .Property<BatchFileId>("_batchFileId")
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasColumnName("BatchFileId")
            .IsRequired();
    }
}