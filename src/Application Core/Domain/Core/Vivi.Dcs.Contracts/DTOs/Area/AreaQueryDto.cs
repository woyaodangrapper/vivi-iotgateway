namespace Vivi.Dcs.Contracts.DTOs;

/// <summary>
/// 智能设备DTO
/// </summary>
public class AreaQueryDTO : OutputBaseAuditDTO
{

    /// <summary>
    /// 区域名称，例如 “A区”、“江南办公区”
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// 区域编码，如 REG001，用于快速索引
    /// </summary>
    public string? Code { get; set; }

    /// <summary>
    /// 区域类型，如 “楼宇、园区、楼层、功能区” 等
    /// </summary>
    public string? Type { get; set; }

    /// <summary>
    /// 区域层级，例如：0=根区域，1=省，2=市...
    /// </summary>
    public int? Level { get; set; }

    /// <summary>
    /// 行政区划代码，遵循 GB/T 2260 标准
    /// </summary>
    public string? BlockCode { get; set; }

}