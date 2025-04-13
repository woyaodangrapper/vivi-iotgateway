namespace Vivi.Dcs.Contracts.DTOs;

public class UnitRecordsRequestDTO
{
    /// <summary>
    /// 设备传感器ID
    /// </summary>
    public Guid UnitId { get; set; }

    /// <summary>
    /// 传感器能力ID
    /// </summary>
    public Guid CapabId { get; set; }

    /// <summary>
    /// 传感器采集数据值（保留两位小数）
    /// </summary>
    public decimal Value { get; set; }

    /// <summary>
    /// 数据采集时间
    /// </summary>
    public DateTime Timestamp { get; set; } = DateTime.UtcNow;
}