using System.Data.Common;
using System.Reflection;
using ClaimsSubmission.Domain.AggregateModels.BatchFileAggregate;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Core;

namespace ClaimsSubmission.Infrastructure.Persistence.DbContexts;

public class ClaimsSubmissionContext : DbContext
{
    private readonly IMediator _mediator;

    public ClaimsSubmissionContext(
        DbContextOptions<ClaimsSubmissionContext> options,
        IMediator mediator)
        : base(options)
    {
        _mediator = mediator;
    }

    public virtual DbSet<BatchFile> BatchFiles => Set<BatchFile>();
    public virtual DbSet<BatchFileValidationResult> BatchFileValidationResults => Set<BatchFileValidationResult>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
        => modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

    public async Task SaveEntitiesAsync(CancellationToken cancellationToken = default)
    {
        await _mediator.DispatchDomainEventsAsync(this);
        await base.SaveChangesAsync(cancellationToken);
        
        await _mediator.DispatchAsyncDomainEventsAsync(this);
    }
}