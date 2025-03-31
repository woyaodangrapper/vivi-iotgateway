using System.ComponentModel.DataAnnotations;

namespace Vivi.Dcs.Entities;

public class SensorCapabilityEntity : EfEntity
{
    [Required]
    [MaxLength(255)]
    public required string Name { get; set; }  // 传感器能力名称，如温度、湿度、风速等

    [Required]
    [MaxLength(50)]
    public required string Unit { get; set; }  // 传感器能力单位，如℃、%RH、m/s

    public string? Description { get; set; }  // 传感器能力描述
}