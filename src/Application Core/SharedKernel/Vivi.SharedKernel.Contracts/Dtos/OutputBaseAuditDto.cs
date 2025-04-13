namespace Vivi.SharedKernel.Application.Contracts.DTOs;

[Serializable]
public abstract class OutputBaseAuditDTO : OutputDTO
{

    /// <summary>
    /// 创建时间
    /// </summary>
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    /// <summary>
    /// 更新时间
    /// </summary>
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}