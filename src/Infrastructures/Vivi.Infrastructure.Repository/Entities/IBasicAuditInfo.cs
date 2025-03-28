namespace Vivi.Infrastructure.Entities
{
    public interface IBasicAuditInfo
    {
        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// 创建时间/注册时间
        /// </summary>
        public DateTime UpdatedAt { get; set; }
    }
}