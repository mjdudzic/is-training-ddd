using MediatR;

namespace ClaimsVetting.Domain.AggregateModels.ClaimAggregate.Events;

public record ClaimMovedBackForReVetting(ClaimId Id) : INotification;