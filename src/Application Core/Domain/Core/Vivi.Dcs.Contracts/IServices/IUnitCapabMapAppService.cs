using Vivi.Dcs.Contracts.DTOs;
using Vivi.SharedKernel.Application.Contracts.Attributes;

namespace Vivi.Dcs.Contracts.IServices;

public interface IUnitCapabMapAppService : ICreateUnitCapabMapCommand, IDeleteUnitCapabMapCommand, IUpdateUnitCapabMapCommand, IAppService
{
    /// <summary>
    /// 获取传感器能力映射列表
    /// </summary>
    /// <returns></returns>
    [OperateLog(LogName = "查询传感器能力映射")]
    Task<SearchPage<UnitCapabMapDto>> GetPagedAsync(UnitCapabMapQueryDto input);
}

public interface ICreateUnitCapabMapCommand
{
    /// <summary>
    /// 新增传感器能力映射
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [OperateLog(LogName = "新增传感器能力映射")]
    Task<AppSrvResult<long>> CreateAsync(UnitCapabMapRequestDto input);
}

public interface IDeleteUnitCapabMapCommand
{
    /// <summary>
    /// 删除传感器能力映射
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [OperateLog(LogName = "删除传感器能力映射")]
    Task<AppSrvResult> DeleteAsync(Guid id);
}

public interface IUpdateUnitCapabMapCommand
{
    /// 修改传感器能力映射
    /// </summary>
    /// <param name="id"></param>
    /// <param name="input"></param>
    /// <returns></returns>
    [OperateLog(LogName = "修改传感器能力映射")]
    Task<AppSrvResult> UpdateAsync(UnitCapabMapRequestDto input);
}