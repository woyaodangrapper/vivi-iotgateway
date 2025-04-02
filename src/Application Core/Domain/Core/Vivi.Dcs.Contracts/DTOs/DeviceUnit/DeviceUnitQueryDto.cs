namespace Vivi.Dcs.Contracts.DTOs;

/// <summary>
/// 智能设备DTO
/// </summary>
public class DeviceUnitQueryDto : SearchPagedDto
{
    /// <summary>
    /// 所属设备ID
    /// </summary>
    public Guid DeviceId { get; set; }

    /// <summary>
    /// 传感器类型，如温度传感器、压力传感器
    /// </summary>
    public string UnitType { get; set; } = string.Empty;

    /// <summary>
    /// 传感器安装位置（可选）
    /// </summary>
    public string? InstallationPosition { get; set; }
}