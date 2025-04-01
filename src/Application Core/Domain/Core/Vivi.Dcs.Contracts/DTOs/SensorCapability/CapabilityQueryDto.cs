namespace Vivi.Dcs.Contracts.DTOs;

/// <summary>
/// 智能设备DTO
/// </summary>
public class CapabilityQueryDto : SearchPagedDto
{
    /// <summary>
    /// 传感器能力名称，如温度、湿度、风速等
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// 传感器能力单位，如℃、%RH、m/s
    /// </summary>
    public string Unit { get; set; } = string.Empty;

    /// <summary>
    /// 传感器能力描述
    /// </summary>
    public string? Description { get; set; }
}