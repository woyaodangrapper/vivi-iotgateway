﻿//------------------------------------------------------------------------------
//  此代码版权声明为全文件覆盖，如有原作者特别声明，会在下方手动补充
//  此代码版权（除特别声明外的代码）归作者本人Diego所有
//  源代码使用协议遵循本仓库的开源协议及附加协议
//  Gitee源代码仓库：https://gitee.com/diego2098/ThingsGateway
//  Github源代码仓库：https://github.com/kimdiego2098/ThingsGateway
//  使用文档：https://diego2098.gitee.io/thingsgateway-docs/
//  QQ群：605534569
//------------------------------------------------------------------------------

using Mapster;

using ThingsGateway.Admin.Application;
using ThingsGateway.Foundation;

using TouchSocket.Core;

namespace ThingsGateway.Plugin.QuestDB;

/// <summary>
/// RabbitMQProducer
/// </summary>
public partial class QuestDBProducer : BusinessBaseWithCacheIntervalVarModel<QuestDBHistoryValue>
{
    private TypeAdapterConfig _config;

    protected override void VariableChange(VariableRunTime variableRunTime, VariableData variable)
    {
        AddQueueVarModel(new(variableRunTime.Adapt<QuestDBHistoryValue>()));
        base.VariableChange(variableRunTime, variable);
    }

    protected override Task<OperResult> UpdateVarModel(IEnumerable<CacheDBItem<QuestDBHistoryValue>> item, CancellationToken cancellationToken)
    {
        return UpdateVarModel(item.Select(a => a.Value), cancellationToken);
    }

    private async Task<OperResult> UpdateVarModel(IEnumerable<QuestDBHistoryValue> item, CancellationToken cancellationToken)
    {
        var result = await InserableAsync(item.ToList(), cancellationToken);
        if (success != result.IsSuccess)
        {
            if (!result.IsSuccess)
                LogMessage.LogWarning(result.ToString());
            success = result.IsSuccess;
        }

        return result;
    }

    #region 方法

    private async Task<OperResult> InserableAsync(List<QuestDBHistoryValue> dbInserts, CancellationToken cancellationToken)
    {
        try
        {
            var db = BusinessDatabaseUtil.GetDb(_driverPropertys.DbType, _driverPropertys.BigTextConnectStr);
            db.Ado.CancellationToken = cancellationToken;
            var result = await db.Insertable(dbInserts).UseParameter().ExecuteCommandAsync();//不要加分表
            //var result = await db.Insertable(dbInserts).SplitTable().ExecuteCommandAsync();
            if (result > 0)
            {
                LogMessage.Trace($"TableName：{nameof(QuestDBHistoryValue)}，Count：{result}");
            }
            return new();
        }
        catch (Exception ex)
        {
            return new(ex);
        }
    }

    #endregion 方法
}