namespace BuildingBlocks.Messaging.Events
{
	public class IntegrationEvent
	{
		Guid EventId => Guid.NewGuid();
		public DateTime? OccuredOn => DateTime.Now;
		public string EventType => GetType().AssemblyQualifiedName!;
	}
}
