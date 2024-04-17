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


using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;

using System.Data;

using ThingsGateway.Core.Extension;
using ThingsGateway.Gateway.Application;
using ThingsGateway.Razor;

namespace ThingsGateway.Gateway.Razor;

public partial class ChannelPage
{
    [Inject]
    [NotNull]
    private IChannelService? ChannelService { get; set; }

    private Channel? SearchModel { get; set; } = new();

    #region 查询

    private async Task<QueryData<Channel>> OnQueryAsync(QueryPageOptions options)
    {
        var data = await ChannelService.PageAsync(options);
        return data;
    }

    #endregion 查询

    #region 修改

    private async Task DeleteAllAsync()
    {
        try
        {
            await ChannelService.ClearChannelAsync();
        }
        catch (Exception ex)
        {
            await ToastService.Warning(null, $"{ex.Message}");
        }
    }

    private async Task<bool> Save(Channel channel, ItemChangedType itemChangedType)
    {
        try
        {
            return await ChannelService.SaveChannelAsync(channel, itemChangedType);
        }
        catch (Exception ex)
        {
            await ToastService.Warning(null, $"{ex.Message}");
            return false;
        }
    }

    private async Task<bool> Delete(IEnumerable<Channel> channels)
    {
        try
        {
            return await ChannelService.DeleteChannelAsync(channels.Select(a => a.Id));
        }
        catch (Exception ex)
        {
            await ToastService.Warning(null, $"{ex.Message}");
            return false;
        }
    }

    #endregion 修改

    #region 导出

    [Inject]
    [NotNull]
    private ITableExport? TableExport { get; set; }

    [Inject]
    private IJSRuntime JSRuntime { get; set; }

    private async Task ExcelExportAsync(ITableExportContext<Channel> tableExportContext)
    {
        await using var ajaxJS = await JSRuntime.InvokeAsync<IJSObjectReference>("import", $"{WebsiteConst.DefaultResourceUrl}js/downloadFile.js");
        string url = "api/gatewayExport/channel";
        string fileName = DateTime.Now.ToFileDateTimeFormat();
        var dtoObject = tableExportContext.BuildQueryPageOptions();
        await ajaxJS.InvokeVoidAsync("blazor_downloadFile", url, fileName, dtoObject);

        // 返回 true 时自动弹出提示框
        await ToastService.Default();
    }

    private async Task ExcelImportAsync(ITableExportContext<Channel> tableExportContext)
    {
        var op = new DialogOption()
        {
            Title = Localizer["ImportExcel"],
            ShowFooter = false,
            ShowCloseButton = false,
            Size = Size.ExtraLarge
        };

        Func<IBrowserFile, Task<Dictionary<string, ImportPreviewOutputBase>>> preview = (a => ChannelService.PreviewAsync(a));
        Func<Dictionary<string, ImportPreviewOutputBase>, Task> import = (value => ChannelService.ImportChannelAsync(value));
        op.Component = BootstrapDynamicComponent.CreateComponent<ImportExcel>(new Dictionary<string, object?>
        {
             {nameof(ImportExcel.Import),import },
            {nameof(ImportExcel.Preview),preview },
        });
        await DialogService.Show(op);

        await table.QueryAsync();
    }

    #endregion 导出
}