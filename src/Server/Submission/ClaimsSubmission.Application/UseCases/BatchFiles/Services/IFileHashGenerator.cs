using Microsoft.AspNetCore.Http;

namespace Eclaims.Submission.Application.UseCases.BatchFiles.Services;

public interface IFileHashGenerator
{
    Task<byte[]> Execute(IFormFile file);
}