using System.Text.Json.Nodes;

namespace Vivi.Dcs.Contracts.DTOs;

public class DeviceRequestDTO : OutputBaseAuditDTO
{
    public Guid Id { get; set; }

    /// <summary>
    /// 设备名称，如中央空调、风机盘管等
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// 设备型号
    /// </summary>
    public short? Model { get; set; }

    /// <summary>
    /// 设备编号
    /// </summary>
    public string? Number { get; set; } = string.Empty;

    /// <summary>
    /// 设备生产厂家
    /// </summary>
    public string? Manufacturer { get; set; }

    /// <summary>
    /// 设备安装位置
    /// </summary>
    public JsonNode? InstallationLocation { get; set; }

    /// <summary>
    /// 设备状态：
    /// </summary>
    public short? Status { get; set; } = 0;


}