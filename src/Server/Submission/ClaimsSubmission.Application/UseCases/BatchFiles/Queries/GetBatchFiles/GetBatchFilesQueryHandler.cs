using MediatR;

namespace ClaimsSubmission.Application.UseCases.BatchFiles.Queries.GetBatchFiles;

public class GetBatchFilesQueryHandler : IRequestHandler<GetBatchFilesQuery, IEnumerable<BatchFileDto>>
{
    private readonly IBatchFileQueryService _batchFileQueryService;

    public GetBatchFilesQueryHandler(IBatchFileQueryService batchFileQueryService)
    {
        _batchFileQueryService = batchFileQueryService;
    }

    public Task<IEnumerable<BatchFileDto>> Handle(
        GetBatchFilesQuery request,
        CancellationToken cancellationToken)
    {
        return _batchFileQueryService.GetBatchFiles();
    }
}