using System.ComponentModel.DataAnnotations;

namespace Vivi.Dcs.Entities;

public class SmartDeviceSensorEntity : EfEntity
{

    [Required]
    public Guid DeviceId { get; set; }  // 所属设备ID

    [Required]
    [MaxLength(100)]
    public required string SensorType { get; set; }  // 传感器类型，如温度传感器、压力传感器

    [MaxLength(255)]
    public string? InstallationPosition { get; set; }  // 传感器安装位置

}