namespace Vivi.Infrastructure.Entities
{
    public class Entity : IEntity<Guid>
    {
        public Guid Id { get; set; }
    }
}