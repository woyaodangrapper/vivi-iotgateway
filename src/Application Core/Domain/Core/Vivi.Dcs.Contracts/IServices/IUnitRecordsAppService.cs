using Vivi.Dcs.Contracts.DTOs;
using Vivi.SharedKernel.Contracts.Attributes;

namespace Vivi.Dcs.Contracts.IServices;

public interface IUnitRecordsAppService : ICreateUnitRecordsCommand, IDeleteUnitRecordsCommand, IUpdateUnitRecordsCommand, IAppService
{
    /// <summary>
    /// 获取智能设备传感器日志列表
    /// </summary>
    /// <returns></returns>
    [OperateLog(LogName = "查询智能设备传感器日志")]
    Task<SearchPage<UnitRecordsDTO>> GetPagedAsync(UnitRecordsQueryDTO input);
}

public interface ICreateUnitRecordsCommand
{
    /// <summary>
    /// 新增智能设备传感器日志
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [OperateLog(LogName = "新增智能设备传感器日志")]
    Task<AppSrvResult<IdDTO>> CreateAsync(UnitRecordsRequestDTO input);
}

public interface IDeleteUnitRecordsCommand
{
    /// <summary>
    /// 删除智能设备传感器日志
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [OperateLog(LogName = "删除智能设备传感器日志")]
    Task<AppSrvResult> DeleteAsync(Guid id);
}

public interface IUpdateUnitRecordsCommand
{
    /// 修改智能设备传感器日志
    /// </summary>
    /// <param name="id"></param>
    /// <param name="input"></param>
    /// <returns></returns>
    [OperateLog(LogName = "修改智能设备传感器日志")]
    Task<AppSrvResult> UpdateAsync(UnitRecordsRequestDTO input);
}