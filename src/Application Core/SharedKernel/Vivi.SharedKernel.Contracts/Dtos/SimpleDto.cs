namespace Vivi.SharedKernel.Application.Contracts.DTOs;

/// <summary>
/// 用于解决返回基本类型
/// </summary>
/// <typeparam name="T"></typeparam>
[Serializable]
public class SimpleDTO<T> : IDTO
{
    public SimpleDTO()
    {
    }

    public SimpleDTO(T value)
    {
        Value = value;
    }

    /// <summary>
    /// 需要传递的值
    /// </summary>
    public T Value { get; set; }
}