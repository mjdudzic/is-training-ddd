using ClaimsSubmission.Application.UseCases.Common;
using ClaimsSubmission.Domain.AggregateModels.BatchFileAggregate;
using ClaimsSubmission.Domain.AggregateModels.BatchFileAggregate.Specifications;
using ClaimsSubmission.Domain.SharedKernel;
using MediatR;

namespace ClaimsSubmission.Application.UseCases.BatchFiles.EventHandlers.BatchFileAggregate.BatchFileUploaded;

public class ValidateFileUniquenessCommandHandler : JobCommandHandlerBase<ValidateFileUniquenessCommand>
{
    private readonly IRepository _repository;
    private readonly IAggregateReadRepository<BatchFile> _batchFileReadRepository;
    private readonly IBatchFileDuplicateCheck _batchFileDuplicateCheck;

    public ValidateFileUniquenessCommandHandler(
        IRepository repository,
        IAggregateReadRepository<BatchFile> batchFileReadRepository,
        IBatchFileDuplicateCheck batchFileDuplicateCheck)
    {
        _repository = repository;
        _batchFileReadRepository = batchFileReadRepository;
        _batchFileDuplicateCheck = batchFileDuplicateCheck;
    }

    public override async Task<Unit> Handle(ValidateFileUniquenessCommand command, CancellationToken cancellationToken)
    {
        await base.Handle(command, cancellationToken);

        LogInfo($"Validating file uniqueness for batch file {command.BatchFileId.Value}");

        var batchFile = await _repository.Get(command.BatchFileId);

        //var spec = new BatchFileByIdSpec(command.BatchFileId);
        //var batchFile2 = await _batchFileReadRepository.FirstOrDefaultAsync(spec, cancellationToken);

        if (batchFile is null)
        {
            LogWarning($"Batch file {command.BatchFileId.Value} does not exist");
            return Unit.Value;
        }

        await batchFile.ValidateUniqueness(_batchFileDuplicateCheck);
        await _repository.SaveChanges(cancellationToken);

        LogInfo($"Validation succeeded? {batchFile.IsUnique}");

        return Unit.Value;
    }
}