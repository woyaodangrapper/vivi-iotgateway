﻿#region copyright
//------------------------------------------------------------------------------
//  此代码版权声明为全文件覆盖，如有原作者特别声明，会在下方手动补充
//  此代码版权（除特别声明外的代码）归作者本人Diego所有
//  源代码使用协议遵循本仓库的开源协议及附加协议
//  Gitee源代码仓库：https://gitee.com/diego2098/ThingsGateway
//  Github源代码仓库：https://github.com/kimdiego2098/ThingsGateway
//  使用文档：https://diego2098.gitee.io/thingsgateway/
//  QQ群：605534569
//------------------------------------------------------------------------------
#endregion

using Microsoft.Extensions.Logging;

using TouchSocket.Core;

namespace ThingsGateway.Web.Foundation
{
    /// <summary>
    /// 扩展
    /// </summary>
    public static class PluginExtension
    {
        /// <summary>
        /// <see cref="TouchSocket"/> 日志输出
        /// </summary>
        public static void Log_Out(ILogger logger, LogType arg1, object arg2, string arg3, Exception arg4)
        {
            switch (arg1)
            {
                case LogType.None:
                    logger?.Log(LogLevel.None, 0, arg4, arg3);
                    break;
                case LogType.Trace:
                    logger?.Log(LogLevel.Trace, 0, arg4, arg3);
                    break;
                case LogType.Debug:
                    logger?.Log(LogLevel.Debug, 0, arg4, arg3);
                    break;
                case LogType.Info:
                    logger?.Log(LogLevel.Information, 0, arg4, arg3);
                    break;
                case LogType.Warning:
                    logger?.Log(LogLevel.Warning, 0, arg4, arg3);
                    break;
                case LogType.Error:
                    logger?.Log(LogLevel.Error, 0, arg4, arg3);
                    break;
                case LogType.Critical:
                    logger?.Log(LogLevel.Critical, 0, arg4, arg3);
                    break;
                default:
                    break;
            }
        }
    }
}
