using ClaimsSubmission.Application.UseCases.BatchFiles.Services;
using ClaimsSubmission.Domain.AggregateModels.BatchFileAggregate;
using ClaimsSubmission.Domain.SharedKernel;
using Eclaims.Submission.Application.UseCases.BatchFiles.Services;
using MediatR;

namespace ClaimsSubmission.Application.UseCases.BatchFiles.Commands.UploadBatchFile;

public class UploadBatchFileCommandHandler : IRequestHandler<UploadBatchFileCommand>
{
    private readonly IBatchFileStorageService _batchFileStorageService;
    private readonly IFileHashGenerator _fileHashGenerator;
    private readonly IBatchFileValidationService _batchFileValidationService;
    private readonly IRepository _repository;
    private readonly ICurrentDateTime _currentDateTime;

    public UploadBatchFileCommandHandler(
        IBatchFileStorageService batchFileStorageService,
        IFileHashGenerator fileHashGenerator,
        IBatchFileValidationService batchFileValidationService,
        IRepository repository,
        ICurrentDateTime currentDateTime)
    {
        _batchFileStorageService = batchFileStorageService;
        _fileHashGenerator = fileHashGenerator;
        _batchFileValidationService = batchFileValidationService;
        _repository = repository;
        _currentDateTime = currentDateTime;
    }

    public async Task<Unit> Handle(UploadBatchFileCommand request, CancellationToken cancellationToken)
    {
        var fileInfo = await _batchFileStorageService.SaveFile(request.HealthcareFacilityId, request.File);
        var fileHash = await _fileHashGenerator.Execute(request.File);
        var batchFile = new BatchFile(
            request.HealthcareFacilityId,
            fileInfo.OriginalFileName,
            Path.GetFileName(fileInfo.FilePath),
            fileHash,
            _currentDateTime);

        await batchFile.Upload(_batchFileValidationService);

        _repository.Add(batchFile);
        await _repository.SaveChanges(cancellationToken);

        return Unit.Value;
    }
}