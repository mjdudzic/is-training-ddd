using MediatR;

namespace ClaimsVetting.Domain.AggregateModels.ClaimAggregate.Events;

public record ClaimRejected(ClaimId Id) : INotification;