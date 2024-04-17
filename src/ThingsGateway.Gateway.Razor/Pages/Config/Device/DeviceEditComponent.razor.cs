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


using Microsoft.AspNetCore.Components.Web;

using ThingsGateway.Gateway.Application;

namespace ThingsGateway.Gateway.Razor;

public partial class DeviceEditComponent
{
    private IEnumerable<IEditorItem> PluginPropertyEditorItems;

    [NotNull]
    public IEnumerable<SelectedItem> Channels { get; set; }

    [Parameter]
    [EditorRequired]
    [NotNull]
    public Device? Model { get; set; }

    [Parameter]
    [EditorRequired]
    [NotNull]
    public IEnumerable<SelectedItem> PluginNames { get; set; }

    [Parameter]
    [EditorRequired]
    [NotNull]
    public PluginTypeEnum PluginType { get; set; }

    [Parameter]
    [EditorRequired]
    [NotNull]
    public Func<VirtualizeQueryOption, Device, Task<QueryData<SelectedItem>>> RedundantDevicesQuery { get; set; }

    [Inject]
    [NotNull]
    private IPluginService PluginService { get; set; }

    [Inject]
    [NotNull]
    private IChannelService ChannelService { get; set; }

    [Inject]
    private IStringLocalizer<Channel> ChannelLocalizer { get; set; }

    protected override void OnParametersSet()
    {
        Channels = ChannelService.GetAll().BuildChannelSelectList();
        base.OnParametersSet();
    }

    private async Task AddChannel(MouseEventArgs args)
    {
        Channel channel = new();

        var op = new DialogOption()
        {
            Title = ChannelLocalizer["SaveChannel"],
            ShowFooter = false,
            ShowCloseButton = false,
            Size = Size.ExtraLarge
        };
        op.Component = BootstrapDynamicComponent.CreateComponent<ChannelEditComponent>(new Dictionary<string, object?>
        {
            [nameof(ChannelEditComponent.Model)] = channel,
            [nameof(ChannelEditComponent.ValidateEnable)] = true,
            [nameof(ChannelEditComponent.OnValidSubmit)] = async () =>
            {
                await ChannelService.SaveChannelAsync(channel, ItemChangedType.Add);
            },
        });
        await DialogService.Show(op);
    }

    private Task OnPluginNameChanged(SelectedItem selectedItem)
    {
        try
        {
            var data = PluginService.GetDriverPropertyTypes(selectedItem?.Value);
            Model.PluginPropertyModel = new ModelValueValidateForm() { Value = data.Model };
            PluginPropertyEditorItems = data.EditorItems;
            if (Model.DevicePropertys?.Any() == true)
            {
                PluginServiceUtil.SetModel(Model.PluginPropertyModel.Value, Model.DevicePropertys);
            }
        }
        catch (Exception ex)
        {
            System.Console.WriteLine(ex);
        }
        return Task.CompletedTask;
    }

    private async Task<QueryData<SelectedItem>> OnRedundantDevicesQuery(VirtualizeQueryOption option)
    {
        if (RedundantDevicesQuery != null)
            return await RedundantDevicesQuery.Invoke(option, Model);
        else
            return new();
    }
}