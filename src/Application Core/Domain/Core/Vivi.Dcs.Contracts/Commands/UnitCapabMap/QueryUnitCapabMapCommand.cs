namespace Vivi.Dcs.Contracts.Commands;

public class QueryUnitCapabMapCommand : SearchPagedDTO
{

    /// <summary>
    /// 设备传感器ID
    /// </summary>
    public Guid UnitId { get; set; }

    /// <summary>
    /// 传感器能力ID
    /// </summary>
    public Guid CapabId { get; set; }
}