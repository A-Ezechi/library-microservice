
namespace library_MicroService.BuildingBlocks.BuildingBlocks.Messaging
{
    public record IntegrationEvent
    {
        public Guid Id { get; } = Guid.NewGuid();
        public DateTime OccuredOn { get; } = DateTime.UtcNow;
        public string EventType => GetType().AssemblyQualifiedName!;
    }
}

//IntegrationEvent. Will be used to create/track events when an event takes place. E.g User CRUD, Order CRUD, etc.