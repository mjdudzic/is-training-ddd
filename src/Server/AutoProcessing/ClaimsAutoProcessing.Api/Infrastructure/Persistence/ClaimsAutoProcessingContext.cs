using System.Reflection;
using ClaimsAutoProcessing.Api.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClaimsAutoProcessing.Api.Infrastructure.Persistence;

public class ClaimsAutoProcessingContext : DbContext
{
    private readonly IMediator _mediator;

    public ClaimsAutoProcessingContext(
        DbContextOptions<ClaimsAutoProcessingContext> options,
        IMediator mediator)
        : base(options)
    {
        _mediator = mediator;
    }

    public virtual DbSet<Batch> Batches => Set<Batch>();
    public virtual DbSet<BatchClaim> Claims => Set<BatchClaim>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
        => modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
}