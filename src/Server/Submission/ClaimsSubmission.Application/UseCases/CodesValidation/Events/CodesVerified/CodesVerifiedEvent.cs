using ClaimsSubmission.Domain.AggregateModels.BatchFileAggregate;
using MediatR;

namespace ClaimsSubmission.Application.UseCases.CodesValidation.Events.CodesVerified;

public record CodesVerifiedEvent(BatchFileId Id, BatchClaimsVerificationResult VerificationResult) : INotification;