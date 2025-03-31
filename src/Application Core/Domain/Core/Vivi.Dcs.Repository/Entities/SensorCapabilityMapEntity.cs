using System.ComponentModel.DataAnnotations;

namespace Vivi.Dcs.Entities;

public class SensorCapabilityMapEntity : EfEntity
{
    [Required]
    public Guid SensorId { get; set; }  // 设备传感器ID

    [Required]
    public Guid CapabilityId { get; set; }  // 传感器能力ID

}