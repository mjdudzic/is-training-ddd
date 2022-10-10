using ClaimsSubmission.Domain.AggregateModels.BatchFileAggregate;
using ClaimsSubmission.Infrastructure.Persistence.DbContexts;
using Microsoft.Extensions.Logging;

namespace ClaimsSubmission.Infrastructure.DomainServices.Common;

public class BatchFileWriteRepository : IRepository
{
    private readonly ClaimsSubmissionContext _context;
    private readonly ILogger<BatchFileWriteRepository> _logger;

    public BatchFileWriteRepository(ClaimsSubmissionContext context, ILogger<BatchFileWriteRepository> logger)
    {
        _context = context;
        _logger = logger;
    }

    public void Add(BatchFile batchFile)
    {
        _context.Add(batchFile);
    }

    public ValueTask<BatchFile?> Get(BatchFileId batchFileId)
    {
        return _context.BatchFiles.FindAsync(batchFileId);
    }

    public Task SaveChanges(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Context @{context}", _context.ContextId.InstanceId);
        return _context.SaveEntitiesAsync(cancellationToken);
    }
}