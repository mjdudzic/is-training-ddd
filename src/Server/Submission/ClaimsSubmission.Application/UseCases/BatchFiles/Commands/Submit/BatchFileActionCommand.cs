using ClaimsSubmission.Domain.AggregateModels.BatchFileAggregate;
using MediatR;

namespace ClaimsSubmission.Application.UseCases.BatchFiles.Commands.Submit;

public record BatchFileActionCommand(BatchFileId BatchFile, BatchFileAction Action) : IRequest<SubmittedBatchDto>;