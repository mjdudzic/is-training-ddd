using System.Reflection;
using ClaimsAutoProcessing.Application;
using ClaimsAutoProcessing.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClaimsAutoProcessing.Infrastructure.Persistence.DbContexts;

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