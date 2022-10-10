using ClaimsSubmission.Domain.AggregateModels.BatchFileAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClaimsSubmission.Infrastructure.Persistence.Configurations;

public class BatchFileConfiguration : IEntityTypeConfiguration<BatchFile>
{
    public void Configure(EntityTypeBuilder<BatchFile> builder)
    {
        builder.ToTable("BatchFile");

        builder.Ignore(e => e.Events);

        builder.Property(e => e.Id);

        builder.Property(e => e.Id)
            .HasColumnName("Id")
            .HasMaxLength(Guid.NewGuid().ToString().Length)
            .HasConversion(id => id.Value, id => new BatchFileId(id));

        builder.Property(e => e.FileOriginalName);
        builder.Property(e => e.FileInternalName);
        builder.Property(e => e.FileHash);
        builder.Property(e => e.CreatedAt);
        builder.Property(e => e.SubmittedAt);
        builder.Property(e => e.IsUnique);
        builder.Property(e => e.IsSubmittable);

        builder.Property(e => e.HealthcareFacilityId)
            .HasColumnName("HealthcareFacilityId")
            .HasMaxLength(Guid.NewGuid().ToString().Length)
            .HasConversion(id => id.AccreditationCode, id => new HealthcareFacilityId(id));

        builder.Property(e => e.DuplicatedBatchFile)
            .HasColumnName("DuplicatedBatchFileId")
            .HasMaxLength(Guid.NewGuid().ToString().Length)
            .HasConversion(id => id.Value, id => new BatchFileId(id));

        builder.HasOne(b => b.BatchFileValidationResult)
            .WithOne()
            .IsRequired(false)
            .HasForeignKey<BatchFileValidationResult>("_batchFileId");
    }
}