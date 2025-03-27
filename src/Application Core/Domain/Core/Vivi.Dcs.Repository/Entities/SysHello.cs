namespace Vivi.Dcs.Entities;

public class SysHello : EfFullAuditEntity
{
    public string? Content { get; set; }

    public string? Title { get; set; }

    public int? Type { get; set; }
}