namespace Gravity.Infrastructure.Entities
{
    public class Entity : IEntity<long>
    {
        public long Id { get; set; }
    }
}