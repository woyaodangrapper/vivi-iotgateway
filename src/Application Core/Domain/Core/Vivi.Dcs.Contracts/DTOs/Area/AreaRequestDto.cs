﻿using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace Vivi.Dcs.Contracts.DTOs;

public class AreaRequestDTO : OutputBaseAuditDTO
{
    private Guid? _pid;
    /// <summary>
    /// 上级区域 ID，支持树结构，如省→市→区
    /// </summary>
    [JsonIgnore]
    public Guid? Pid
    {

        get => _pid;
        set => _pid = value;
    }

    [JsonIgnore] // 避免重复序列化 Guid
    public override Guid Id
    {
        get => base.Id;
        set => base.Id = value;
    }

    [JsonPropertyName("id")]
    public string? IdString
    {
        get => base.Id.ToString();
        set => base.Id = Guid.TryParse(value, out var guid) ? guid : throw new ArgumentNullException(nameof(value), "The provided value for IdString is null or invalid.");
    }
    [JsonPropertyName("pid")]
    public string? PidString
    {
        get => _pid?.ToString();
        set => _pid = Guid.TryParse(value, out var guid) ? guid : null;
    }


    /// <summary>
    /// 区域名称，例如 “A区”、“江南办公区”
    /// </summary>
    public string? Name { get; set; } = string.Empty;

    /// <summary>
    /// 区域编码，如 REG001，用于快速索引
    /// </summary>
    public string Code { get; set; } = "110000";

    /// <summary>
    /// 区域类型，如 “楼宇、园区、楼层、功能区” 等
    /// </summary>
    public string? Type { get; set; }

    /// <summary>
    /// 区域层级，例如：0=根区域，1=省，2=市...
    /// </summary>
    public int? Level { get; set; }

    /// <summary>
    /// 区域位置，支持坐标、GeoJSON 或多边形字符串，JSONB 格式存储
    /// </summary>
    public JsonNode? Position { get; set; }

    public string BlockCode { get; set; } = "110000";

}