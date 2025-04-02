namespace Vivi.SharedKernel.Application.Contracts.Dtos;

[Serializable]
public abstract class OutputDTO : IDto
{
    /// <summary>
    /// 创建时间
    /// </summary>
    public virtual DateTime? CreatedAt { get; set; }
    /// <summary>
    /// 更新时间
    /// </summary>
    public virtual DateTime? UpdatedAt { get; set; }
}