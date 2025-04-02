namespace Vivi.Dcs.Application.Commands;

public class UpdateDeviceCommand : BaseCommand
{
    /// <summary>
    /// 设备名称，如中央空调、风机盘管等
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// 设备型号
    /// </summary>
    public string? Model { get; set; }

    /// <summary>
    /// 设备生产厂家
    /// </summary>
    public string? Manufacturer { get; set; }

    /// <summary>
    /// 设备安装位置
    /// </summary>
    public string? InstallationLocation { get; set; }
}