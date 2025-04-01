﻿namespace Vivi.Dcs.Contracts.DTOs;

/// <summary>
/// 传感器日志DTO
/// </summary>
public class SensorDto : OutputBaseAuditDTO
{
    /// <summary>
    /// 传感器数据唯一ID，UUID
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

    /// <summary>
    /// 传感器采集数据值（保留两位小数）
    /// </summary>
    public decimal Value { get; set; }

    /// <summary>
    /// 数据采集时间
    /// </summary>
    public DateTime Timestamp { get; set; } = DateTime.UtcNow;
}