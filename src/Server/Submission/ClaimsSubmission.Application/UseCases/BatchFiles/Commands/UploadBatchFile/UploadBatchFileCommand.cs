using ClaimsSubmission.Domain.AggregateModels.BatchFileAggregate;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace ClaimsSubmission.Application.UseCases.BatchFiles.Commands.UploadBatchFile;

public record UploadBatchFileCommand(HealthcareFacilityId HealthcareFacilityId, IFormFile File) : IRequest;