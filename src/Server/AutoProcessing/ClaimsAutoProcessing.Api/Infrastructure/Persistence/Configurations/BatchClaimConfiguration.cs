using ClaimsAutoProcessing.Api.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClaimsAutoProcessing.Api.Infrastructure.Persistence.Configurations;

public class BatchClaimConfiguration : IEntityTypeConfiguration<BatchClaim>
{
    public void Configure(EntityTypeBuilder<BatchClaim> builder)
    {
        builder.ToTable("BatchClaim");

        builder.Property(e => e.Id);
        builder.Property(e => e.DiagnosisCode);
        builder.Property(e => e.PatientBirthDate);
        builder.Property(e => e.PatientInsuranceNumber);
        builder.Property(e => e.PatientInsuranceValidity);
        builder.Property(e => e.OriginalAmount);
        builder.Property(e => e.FinalAmount);
        builder.Property(e => e.VettingStatus);
        builder.Property(e => e.SelectedForAudit);
    }
}