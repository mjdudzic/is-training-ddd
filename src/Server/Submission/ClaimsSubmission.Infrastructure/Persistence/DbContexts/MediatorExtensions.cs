using ClaimsSubmission.Domain.AggregateModels.BatchFileAggregate.Events;
using ClaimsSubmission.Domain.SeedWork;
using MediatR;

namespace ClaimsSubmission.Infrastructure.Persistence.DbContexts
{
	public static class MediatorExtensions
	{
		public static async Task DispatchDomainEventsAsync(this IMediator mediator, ClaimsSubmissionContext dbContext)
		{
			var domainEntities = dbContext.ChangeTracker
				.Entries<Entity>()
				.Where(x => x.Entity.Events != null && x.Entity.Events.Any())
				.ToList();

			var domainEvents = domainEntities
				.SelectMany(x => x.Entity.Events)
                .Where(x => x is not IAsyncDomainEvent)
				.ToList();

			domainEntities
				.ForEach(entity => entity.Entity.ClearDomainEvents());

			var tasks = domainEvents
				.Select(async (domainEvent) => {
					await mediator.Publish(domainEvent);
				});

			await Task.WhenAll(tasks);
		}

        public static async Task DispatchAsyncDomainEventsAsync(this IMediator mediator, ClaimsSubmissionContext dbContext)
        {
            var domainEntities = dbContext.ChangeTracker
                .Entries<Entity>()
                .Where(x => x.Entity.Events != null && x.Entity.Events.Any())
                .ToList();

            var domainEvents = domainEntities
                .SelectMany(x => x.Entity.Events)
                .Where(x => x is IAsyncDomainEvent)
                .ToList();

            domainEntities
                .ForEach(entity => entity.Entity.ClearDomainEvents());

            var tasks = domainEvents
                .Select(async (domainEvent) => {
                    await mediator.Publish(domainEvent);
                });

            await Task.WhenAll(tasks);
        }
    }
}
