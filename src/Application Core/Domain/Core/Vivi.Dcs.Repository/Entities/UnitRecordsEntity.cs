using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vivi.Dcs.Entities;

/// <summary>
/// 传感器日志表
/// </summary>
public class UnitRecordsEntity : EfEntity
{
    [Required]
    public Guid UnitId { get; set; }  // 设备传感器ID

    [Required]
    public Guid CapabilityId { get; set; }  // 传感器能力ID

    [Required]
    [Column(TypeName = "numeric(10,2)")]
    public decimal Value { get; set; }  // 传感器采集数据值

    public DateTime Timestamp { get; set; } = DateTime.UtcNow;  // 数据采集时间
}