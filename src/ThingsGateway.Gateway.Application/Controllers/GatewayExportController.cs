﻿
//------------------------------------------------------------------------------
//  此代码版权声明为全文件覆盖，如有原作者特别声明，会在下方手动补充
//  此代码版权（除特别声明外的代码）归作者本人Diego所有
//  源代码使用协议遵循本仓库的开源协议及附加协议
//  Gitee源代码仓库：https://gitee.com/diego2098/ThingsGateway
//  Github源代码仓库：https://github.com/kimdiego2098/ThingsGateway
//  使用文档：https://diego2098.gitee.io/thingsgateway-docs/
//  QQ群：605534569
//------------------------------------------------------------------------------



using BootstrapBlazor.Components;

using Microsoft.AspNetCore.Mvc;

namespace ThingsGateway.Gateway.Application;

/// <summary>
/// 导出文件
/// </summary>
[Route("api/gatewayExport")]
[LoggingMonitor]
public class GatewayExportController : ControllerBase
{
    private readonly IBackendLogService _backendLogService;
    private readonly IRpcLogService _rpcLogService;
    private readonly IChannelService _channelService;
    private readonly IDeviceService _deviceService;
    private readonly IVariableService _variableService;

    /// <summary>
    /// <inheritdoc cref="GatewayExportController"/>
    /// </summary>
    public GatewayExportController(
        IChannelService channelService,
        IDeviceService deviceService,
        IVariableService variableService,
        IBackendLogService backendLogService,
        IRpcLogService rpcLogService
        )
    {
        _backendLogService = backendLogService;
        _rpcLogService = rpcLogService;
        _channelService = channelService;
        _deviceService = deviceService;
        _variableService = variableService;
    }

    /// <summary>
    /// 下载通道
    /// </summary>
    /// <returns></returns>
    [HttpGet("channel")]
    public async Task<IActionResult> DownloadChannelAsync([FromQuery] QueryPageOptions input)
    {
        input.IsPage = false;
        input.IsVirtualScroll = false;

        var fileStreamResult = await _channelService.ExportChannelAsync(input);
        return fileStreamResult;
    }

    /// <summary>
    /// 下载设备
    /// </summary>
    /// <returns></returns>
    [HttpGet("collectdevice")]
    public async Task<IActionResult> DownloadCollectDeviceAsync([FromQuery] QueryPageOptions input)
    {
        input.IsPage = false;
        input.IsVirtualScroll = false;

        var fileStreamResult = await _deviceService.ExportDeviceAsync(input, PluginTypeEnum.Collect);
        return fileStreamResult;
    }

    /// <summary>
    /// 下载设备
    /// </summary>
    /// <returns></returns>
    [HttpGet("businessdevice")]
    public async Task<IActionResult> DownloadBusinessDeviceAsync([FromQuery] QueryPageOptions input)
    {
        input.IsPage = false;
        input.IsVirtualScroll = false;
        var fileStreamResult = await _deviceService.ExportDeviceAsync(input, PluginTypeEnum.Business);
        return fileStreamResult;
    }

    /// <summary>
    /// 下载变量
    /// </summary>
    /// <returns></returns>
    [HttpGet("variable")]
    public async Task<IActionResult> DownloadDeviceAsync([FromQuery] QueryPageOptions input)
    {
        input.IsPage = false;
        input.IsVirtualScroll = false;

        var fileStreamResult = await _variableService.ExportVariableAsync(input);
        return fileStreamResult;
    }
}