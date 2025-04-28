using System.Text.Json.Nodes;

namespace Vivi.Dcs.Contracts.DTOs;

/// <summary>
/// 智能设备DTO
/// </summary>
public class DeviceDTO : OutputBaseAuditDTO
{

    /// <summary>
    /// 设备唯一编码
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// 设备名称，如中央空调、风机盘管等
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// 设备编号
    /// </summary>
    public string? Number { get; set; } = string.Empty;

    /// <summary>
    /// 设备型号
    /// </summary>
    public short? Model { get; set; }

    /// <summary>
    /// 设备生产厂家
    /// </summary>
    public string? Manufacturer { get; set; }

    /// <summary>
    /// 设备安装位置
    /// </summary>
    public JsonNode? InstallationLocation { get; set; }

    /// <summary>
    /// fail - 通信失败，设备无法正常通信；
    /// audit - 无效设备，设备不符合使用条件或无效；
    /// executing - 运行中，设备正在工作或运行；
    /// pending - 未启用，设备尚未投入使用；
    /// finish - 生命周期结束，设备已达到使用寿命或已退役；
    /// </summary>
    public short Status { get; set; } = 0;
}