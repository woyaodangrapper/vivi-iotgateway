using System.Text.Json.Nodes;

namespace Vivi.Dcs.Application.Commands;

public class CreateAreaCommand : BaseCommand
{
    public Guid? Pid { get; set; }

    /// <summary>
    /// 区域名称，例如 “A区”、“江南办公区”
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// 区域编码，如 REG001，用于快速索引
    /// </summary>
    public string Code { get; set; } = "110000";

    /// <summary>
    /// 区域类型，如 “楼宇、园区、楼层、功能区” 等
    /// </summary>
    public string? Type { get; set; }

    /// <summary>
    /// 区域层级，例如：0=根区域，1=省，2=市...
    /// </summary>
    public int? Level { get; set; }

    /// <summary>
    /// 区域位置，支持坐标、GeoJSON 或多边形字符串，JSONB 格式存储
    /// </summary>
    public JsonNode? Position { get; set; }
}