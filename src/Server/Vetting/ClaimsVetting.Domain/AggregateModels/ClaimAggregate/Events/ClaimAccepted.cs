using MediatR;

namespace ClaimsVetting.Domain.AggregateModels.ClaimAggregate.Events;

public record ClaimAccepted(ClaimId Id) : INotification;