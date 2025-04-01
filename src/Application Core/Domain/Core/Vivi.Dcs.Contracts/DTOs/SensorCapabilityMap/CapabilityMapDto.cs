namespace Vivi.Dcs.Contracts.DTOs;

/// <summary>
/// 传感器能力映射DTO
/// </summary>
public class CapabilityMapDto : OutputBaseAuditDTO
{
    /// <summary>
    /// 传感器能力映射唯一ID，UUID
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// 设备传感器ID
    /// </summary>
    public Guid SensorId { get; set; }

    /// <summary>
    /// 传感器能力ID
    /// </summary>
    public Guid CapabilityId { get; set; }
}