using ClaimsSubmission.Domain.AggregateModels.BatchFileAggregate;
using ClaimsSubmission.Infrastructure.Persistence.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace ClaimsSubmission.Infrastructure.DomainServices.BatchFileAggregate;

public class BatchFileDuplicateCheck : IBatchFileDuplicateCheck
{
    private readonly ClaimsSubmissionContext _context;

    public BatchFileDuplicateCheck(ClaimsSubmissionContext context)
    {
        _context = context;
    }

    public async Task<BatchFileId?> IsDuplicate(BatchFile batchFile)
    {
        return (await _context.BatchFiles
                .Where(b => 
                    b.HealthcareFacilityId == batchFile.HealthcareFacilityId &&
                    b.FileHash == batchFile.FileHash &&
                    b.Id != batchFile.Id)
                .OrderBy(b => b.Id)
                .FirstOrDefaultAsync())
            ?.Id;
    }
}