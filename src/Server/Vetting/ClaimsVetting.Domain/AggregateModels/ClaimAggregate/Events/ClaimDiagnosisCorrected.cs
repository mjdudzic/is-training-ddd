using MediatR;

namespace ClaimsVetting.Domain.AggregateModels.ClaimAggregate.Events;

public record ClaimDiagnosisCorrected(ClaimId Id) : INotification;