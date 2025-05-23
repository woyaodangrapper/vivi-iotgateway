﻿using System.ComponentModel.DataAnnotations;

namespace Vivi.SharedKernel.Application.Contracts.DTOs;

/// <summary>
/// 用于解决API frompost 方式接收 string,int,long等基础类型的问题。
/// </summary>
/// <typeparam name="T"></typeparam>
[Serializable]
public class InputSimpleDTO<T> : IDTO
{
    /// <summary>
    /// 需要传递的值
    /// </summary>
    [Required]
    public T Value { get; set; }
}