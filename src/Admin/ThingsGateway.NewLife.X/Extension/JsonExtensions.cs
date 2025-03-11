//------------------------------------------------------------------------------
//  此代码版权声明为全文件覆盖，如有原作者特别声明，会在下方手动补充
//  此代码版权（除特别声明外的代码）归作者本人Diego所有
//  源代码使用协议遵循本仓库的开源协议及附加协议
//  Gitee源代码仓库：https://gitee.com/diego2098/ThingsGateway
//  Github源代码仓库：https://github.com/kimdiego2098/ThingsGateway
//  使用文档：https://thingsgateway.cn/
//  QQ群：605534569
//------------------------------------------------------------------------------

using Newtonsoft.Json;

namespace ThingsGateway.NewLife.Json.Extension;

/// <summary>
/// json扩展
/// </summary>
public static class JsonExtensions
{
    /// <summary>
    /// 默认Json规则
    /// </summary>
    public static JsonSerializerSettings IndentedOptions;
    public static JsonSerializerSettings NoneIndentedOptions;
    static JsonExtensions()
    {
        IndentedOptions = new JsonSerializerSettings
        {
            Formatting = Formatting.Indented,// 使用缩进格式化输出
            NullValueHandling = NullValueHandling.Ignore, // 忽略空值属性
        };
        IndentedOptions.Converters.Add(new ByteArrayToNumberArrayConverter());
        NoneIndentedOptions = new JsonSerializerSettings
        {
            Formatting = Formatting.None,// 不使用缩进格式化输出
            NullValueHandling = NullValueHandling.Ignore, // 忽略空值属性
        };
        NoneIndentedOptions.Converters.Add(new ByteArrayToNumberArrayConverter());
    }

    /// <summary>
    /// 反序列化
    /// </summary>
    /// <param name="json"></param>
    /// <param name="type"></param>
    /// <param name="jsonSerializerSettings"></param>
    /// <returns></returns>
    public static object FromJsonNetString(this string json, Type type, JsonSerializerSettings? jsonSerializerSettings)
    {
        return Newtonsoft.Json.JsonConvert.DeserializeObject(json, type, jsonSerializerSettings ?? IndentedOptions);
    }


    /// <summary>
    /// 反序列化
    /// </summary>
    /// <param name="json"></param>
    /// <param name="jsonSerializerSettings"></param>
    /// <returns></returns>
    public static T FromJsonNetString<T>(this string json, JsonSerializerSettings? jsonSerializerSettings = null)
    {
        return (T)FromJsonNetString(json, typeof(T), jsonSerializerSettings);
    }


    /// <summary>
    /// 序列化
    /// </summary>
    /// <param name="item"></param>
    /// <param name="jsonSerializerSettings"></param>
    /// <returns></returns>
    public static string ToJsonNetString(this object item, JsonSerializerSettings? jsonSerializerSettings)
    {
        return Newtonsoft.Json.JsonConvert.SerializeObject(item, jsonSerializerSettings ?? IndentedOptions);
    }

    /// <summary>
    /// 序列化
    /// </summary>
    public static string ToJsonNetString(this object item, bool indented = true)
    {
        return Newtonsoft.Json.JsonConvert.SerializeObject(item, indented == false ? NoneIndentedOptions : IndentedOptions);
    }
}
