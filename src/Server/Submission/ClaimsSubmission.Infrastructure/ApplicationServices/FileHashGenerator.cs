using System.Security.Cryptography;
using Eclaims.Submission.Application.UseCases.BatchFiles.Services;
using Microsoft.AspNetCore.Http;

namespace ClaimsSubmission.Infrastructure.ApplicationServices;

public class FileHashGenerator : IFileHashGenerator
{
    public async Task<byte[]> Execute(IFormFile file)
    {
        await using var stream = file.OpenReadStream();
        await using var memoryStream = new MemoryStream();
        using var md5 = MD5.Create();

        if (stream.CanSeek)
            stream.Position = 0;

        await stream.CopyToAsync(memoryStream);

        var hashFile = md5.ComputeHash(memoryStream.ToArray());

        if (stream.CanSeek)
            stream.Position = 0;

        return hashFile;
    }
}