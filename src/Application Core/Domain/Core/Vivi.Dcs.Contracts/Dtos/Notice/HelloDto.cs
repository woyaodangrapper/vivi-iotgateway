namespace Vivi.Dcs.Contracts.Dtos;

/// <summary>
/// 系统通知
/// </summary>
public class HelloDto : OutputBaseAuditDto
{
    /// <summary>
    /// 内容
    /// </summary>
    public string Content { get; set; }

    /// <summary>
    /// 标题
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    /// 类型
    /// </summary>
    public int? Type { get; set; }
}