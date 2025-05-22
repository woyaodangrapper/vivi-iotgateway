namespace Vivi.Dcs.Contracts.Requests;

/// <summary>
/// 远程编排验证请求参数
/// </summary>
public class AsprtuVerify
{
    public string AppId { get; set; }
    public string Address { get; set; }
    public string Timestamp { get; set; }
}