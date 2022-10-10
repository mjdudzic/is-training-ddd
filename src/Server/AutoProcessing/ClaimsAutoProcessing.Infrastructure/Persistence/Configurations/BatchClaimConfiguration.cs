using ClaimsAutoProcessing.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClaimsAutoProcessing.Infrastructure.Persistence.Configurations;

public class BatchClaimConfiguration : IEntityTypeConfiguration<BatchClaim>
{
    public void Configure(EntityTypeBuilder<BatchClaim> builder)
    {
        builder.ToTable("BatchClaim");

        builder.Property(e => e.Id);
        builder.Property(e => e.DiagnosisCode);
        builder.Property(e => e.PatientBirthDate);
        builder.Property(e => e.PatientInsuranceNumber);
        builder.Property(e => e.TotalAmount);
    }
}