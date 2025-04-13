namespace Vivi.Dcs.Contracts.DTOs;

public class UnitCapabMapRequestDTO
{
    /// <summary>
    /// 传感器能力映射唯一ID，UUID
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// 设备传感器ID
    /// </summary>
    public Guid UnitId { get; set; }

    /// <summary>
    /// 传感器能力ID
    /// </summary>
    public Guid CapabId { get; set; }
}