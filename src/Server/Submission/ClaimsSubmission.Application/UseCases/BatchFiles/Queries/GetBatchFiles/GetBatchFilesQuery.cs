using MediatR;

namespace ClaimsSubmission.Application.UseCases.BatchFiles.Queries.GetBatchFiles;

public class GetBatchFilesQuery : IRequest<IEnumerable<BatchFileDto>>
{
}