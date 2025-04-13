﻿namespace Vivi.SharedKernel.Application.Contracts.DTOs;

/// <summary>
/// DTO基类
/// </summary>
/// <typeparam name="TKey"></typeparam>
[Serializable]
public abstract class OutputFullAuditInfoDTO : OutputBaseAuditDTO
{
    /// <summary>
    /// 最后更新人
    /// </summary>
    public virtual long? ModifyBy { get; set; }

    /// <summary>
    /// 最后更新时间
    /// </summary>
    public virtual DateTime? ModifyTime { get; set; }
}