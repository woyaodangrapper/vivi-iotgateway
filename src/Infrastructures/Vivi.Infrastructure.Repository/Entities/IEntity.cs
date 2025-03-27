namespace Vivi.Infrastructure.Entities
{
    public interface IEntity<TKey>
    {
        public TKey Id { get; set; }
    }
}