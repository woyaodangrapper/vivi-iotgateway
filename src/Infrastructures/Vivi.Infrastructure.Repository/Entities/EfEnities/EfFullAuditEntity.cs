namespace Vivi.Infrastructure.Entities
{
    public abstract class EfFullAuditEntity : EfEntity, IFullAuditInfo
    {
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime UpdatedAt { get; set; }

    }
}