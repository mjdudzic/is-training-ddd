using Ardalis.Specification.EntityFrameworkCore;
using ClaimsSubmission.Domain.SeedWork;
using ClaimsSubmission.Domain.SharedKernel;
using ClaimsSubmission.Infrastructure.Persistence.DbContexts;

namespace ClaimsSubmission.Infrastructure.DomainServices.Common;

public class AggregateReadRepository<T> : RepositoryBase<T>, IAggregateReadRepository<T> where T : class, IAggregateRoot
{
    public AggregateReadRepository(ClaimsSubmissionContext dbContext) : base(dbContext)
    {
    }
}