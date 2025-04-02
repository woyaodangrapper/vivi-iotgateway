using Vivi.Dcs.Contracts.DTOs;
using Vivi.SharedKernel.Application.Contracts.Attributes;

namespace Vivi.Dcs.Contracts.IServices;

public interface IUnitCapabAppService : ICreateUnitCapabCommand, IDeleteUnitCapabCommand, IUpdateUnitCapabCommand, IAppService
{
    /// <summary>
    /// 获取传感器能力列表
    /// </summary>
    /// <returns></returns>
    [OperateLog(LogName = "查询传感器能力")]
    Task<SearchPage<UnitCapabDto>> GetPagedAsync(UnitCapabQueryDto input);
}

public interface ICreateUnitCapabCommand
{
    /// <summary>
    /// 新增传感器能力
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [OperateLog(LogName = "新增传感器能力")]
    Task<AppSrvResult<long>> CreateAsync(UnitCapabRequestDto input);
}

public interface IDeleteUnitCapabCommand
{
    /// <summary>
    /// 删除传感器能力
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [OperateLog(LogName = "删除传感器能力")]
    Task<AppSrvResult> DeleteAsync(Guid id);
}

public interface IUpdateUnitCapabCommand
{
    /// 修改传感器能力
    /// </summary>
    /// <param name="id"></param>
    /// <param name="input"></param>
    /// <returns></returns>
    [OperateLog(LogName = "修改传感器能力")]
    Task<AppSrvResult> UpdateAsync(UnitCapabRequestDto input);
}