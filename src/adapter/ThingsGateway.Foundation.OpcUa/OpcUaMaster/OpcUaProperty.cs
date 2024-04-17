//------------------------------------------------------------------------------
//  此代码版权声明为全文件覆盖，如有原作者特别声明，会在下方手动补充
//  此代码版权（除特别声明外的代码）归作者本人Diego所有
//  源代码使用协议遵循本仓库的开源协议及附加协议
//  Gitee源代码仓库：https://gitee.com/diego2098/ThingsGateway
//  Github源代码仓库：https://github.com/kimdiego2098/ThingsGateway
//  使用文档：https://diego2098.gitee.io/thingsgateway-docs/
//  QQ群：605534569
//------------------------------------------------------------------------------

namespace ThingsGateway.Foundation.OpcUa;

/// <summary>
/// OpcUaMaster配置项
/// </summary>
public class OpcUaProperty
{
    /// <summary>
    /// OpcUrl
    /// </summary>
    public string OpcUrl { get; set; } = "opc.tcp://127.0.0.1:49320";

    /// <summary>
    /// 登录账号
    /// </summary>
    public string UserName { get; set; }

    /// <summary>
    /// 登录密码
    /// </summary>
    public string Password { get; set; }

    /// <summary>
    /// 检查域
    /// </summary>
    public bool CheckDomain { get; set; }

    /// <summary>
    /// 更新间隔
    /// </summary>
    public int UpdateRate { get; set; } = 1000;

    /// <summary>
    /// 是否订阅
    /// </summary>
    public bool ActiveSubscribe { get; set; } = true;

    /// <summary>
    /// 分组大小
    /// </summary>
    public int GroupSize { get; set; } = 500;

    /// <summary>
    /// 死区
    /// </summary>
    public double DeadBand { get; set; } = 0;


    public int KeepAliveInterval { get; set; } = 3000;

    /// <summary>
    /// 安全策略
    /// </summary>
    public bool UseSecurity { get; set; } = false;

    /// <summary>
    /// 加载服务端数据类型
    /// </summary>
    public bool LoadType { get; set; } = true;

    /// <inheritdoc/>
    public override string ToString()
    {
        return OpcUrl;
    }
}