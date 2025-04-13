using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Nodes;

namespace Vivi.Dcs.Entities;

/// <summary>
/// 区域表实体
/// </summary>
public class AreaEntity : EfFullAuditEntity
{
    /// <summary>
    /// 上级区域 ID，支持树结构，如省→市→区
    /// </summary>
    public Guid? Pid { get; set; }

    /// <summary>
    /// 区域名称，例如 “A区”、“江南办公区”
    /// </summary>
    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// 区域编码，如 REG001，用于快速索引
    /// </summary>
    [Required]
    [MaxLength(50)]
    public string Code { get; set; } = "110000";

    /// <summary>
    /// 区域类型，如 “楼宇、园区、楼层、功能区” 等
    /// </summary>
    [MaxLength(50)]
    public string? Type { get; set; }

    /// <summary>
    /// 区域层级，例如：0=根区域，1=省，2=市...
    /// </summary>
    public int? Level { get; set; }

    /// <summary>
    /// 区域位置，支持坐标、GeoJSON 或多边形字符串，JSONB 格式存储
    /// </summary>
    [Column(TypeName = "jsonb")]
    public JsonNode? Position { get; set; }

    /// <summary>
    /// 行政区代码，遵循 GB/T 2260 标准
    /// </summary>
    [MaxLength(20)]
    public string BlockCode { get; set; } = "110000";
}