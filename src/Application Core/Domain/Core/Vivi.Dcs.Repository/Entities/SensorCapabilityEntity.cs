using System.ComponentModel.DataAnnotations;

namespace Vivi.Dcs.Entities;

/// <summary>
/// 传感器能力表实体
/// </summary>
public class SensorCapabilityEntity : EfEntity
{
    [Required]
    [MaxLength(255)]
    public string Name { get; set; }  // 传感器能力名称，如温度、湿度、风速等

    [Required]
    [MaxLength(50)]
    public string Unit { get; set; }  // 传感器能力单位，如℃、%RH、m/s

    public string? Description { get; set; }  // 传感器能力描述
}