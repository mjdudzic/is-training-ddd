using Ardalis.Specification;
using ClaimsSubmission.Domain.SeedWork;

namespace ClaimsSubmission.Domain.SharedKernel;

public interface IAggregateReadRepository<T> : IReadRepositoryBase<T> where T : class, IAggregateRoot { }