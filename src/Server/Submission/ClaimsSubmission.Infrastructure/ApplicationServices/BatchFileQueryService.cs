using ClaimsSubmission.Application.UseCases.BatchFiles.Queries.GetBatchFiles;
using Dapper;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;

namespace ClaimsSubmission.Infrastructure.ApplicationServices;

public class BatchFileQueryService : IBatchFileQueryService
{
    private readonly string _connectionString;

    public BatchFileQueryService(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection");
    }

    public async Task<IEnumerable<BatchFileDto>> GetBatchFiles()
    {
        await using var connection = new SqliteConnection(_connectionString);

        var query = @"SELECT 
            b.Id, b.HealthcareFacilityId, b.FileOriginalName, b.CreatedAt, b.IsSubmittable, b.DuplicatedBatchFileId,
            b.SubmittedAt,
            r.ClaimsTotalCount, r.ClaimsValidCount
            FROM BatchFile b
            LEFT JOIN BatchFileValidationResult r ON r.BatchFileId = b.Id
            ORDER BY b.CreatedAt DESC";

        return await connection.QueryAsync<BatchFileDto>(query);
    }
}