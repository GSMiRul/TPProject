using TPProject.Domain.Common;

namespace TPProject.Application.Common.Interfaces;

public interface IDomainEventService
{
    Task Publish(DomainEvent domainEvent);
}
