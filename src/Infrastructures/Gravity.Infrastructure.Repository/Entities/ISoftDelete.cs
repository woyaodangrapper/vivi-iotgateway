namespace Gravity.Infrastructure.Entities
{
    public interface ISoftDelete
    {
        bool IsDeleted { get; set; }
    }
}