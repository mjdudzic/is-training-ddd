using MediatR;

namespace ClaimsVetting.Domain.AggregateModels.ClaimAggregate.Events;

public record ClaimMedicineCorrected(ClaimId Id, int MedicineId) : INotification;