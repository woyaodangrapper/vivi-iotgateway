using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Nodes;

namespace Vivi.Dcs.Entities;

/// <summary>
/// 设备表实体
/// </summary>
public class DeviceEntity : EfFullAuditEntity
{
    /// <summary>
    /// 设备名称，如中央空调、风机盘管等
    /// </summary>
    [Required]
    public string Name { get; set; }

    /// <summary>
    /// 设备编号
    /// </summary>
    public string? Number { get; set; }

    /// <summary>
    /// 设备型号
    /// </summary>
    public short? Model { get; set; }

    /// <summary>
    /// 设备生产厂家
    /// </summary>
    public string? Manufacturer { get; set; }

    /// <summary>
    /// 设备安装位置
    /// </summary>
    [Column(TypeName = "jsonb")]
    public JsonNode? InstallationLocation { get; set; }

    /// <summary>
    /// 设备状态：
    /// </summary>
    public short Status { get; set; } = 0;
}