// ------------------------------------------------------------------------
// 版权信息
// 版权归百小僧及百签科技（广东）有限公司所有。
// 所有权利保留。
// 官方网站：https://baiqian.com
//
// 许可证信息
// 项目主要遵循 MIT 许可证和 Apache 许可证（版本 2.0）进行分发和使用。
// 许可证的完整文本可以在源代码树根目录中的 LICENSE-APACHE 和 LICENSE-MIT 文件中找到。
// ------------------------------------------------------------------------

using System.Text.Json;
using System.Text.Json.Nodes;

using ThingsGateway.Extensions;

namespace ThingsGateway.Shapeless;

/// <summary>
///     流变对象模块帮助类
/// </summary>
internal static class Helpers
{
    /// <summary>
    ///     将 <see cref="JsonNode" /> 转换为目标类型
    /// </summary>
    /// <param name="jsonNode">
    ///     <see cref="JsonNode" />
    /// </param>
    /// <param name="resultType">转换的目标类型</param>
    /// <param name="jsonSerializerOptions">
    ///     <see cref="JsonSerializerOptions" />
    /// </param>
    /// <returns>
    ///     <see cref="object" />
    /// </returns>
    internal static object? DeserializeNode(JsonNode? jsonNode, Type resultType,
        JsonSerializerOptions? jsonSerializerOptions = null) =>
        jsonNode.As(resultType,
            jsonSerializerOptions ??
            new JsonSerializerOptions(JsonSerializerOptions.Default) { Converters = { new ClayJsonConverter() } });
}