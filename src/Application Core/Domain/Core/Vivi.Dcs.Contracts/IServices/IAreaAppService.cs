using Vivi.Dcs.Contracts.DTOs;
using Vivi.SharedKernel.Application.Contracts.Attributes;

namespace Vivi.Dcs.Contracts.IServices;

public interface IAreaAppService : ICreateAreaCommand, IDeleteAreaCommand, IUpdateAreaCommand, IAppService
{
    /// <summary>
    /// 获取地区列表
    /// </summary>
    /// <returns></returns>
    [OperateLog(LogName = "查询地区")]
    Task<List<AreaDTO>> GetListAsync(AreaQueryDTO input);


    /// <summary>
    /// 获取地区树结构
    /// </summary>
    /// <returns></returns>
    [OperateLog(LogName = "查询地区结构")]
    Task<List<AreaTreeNodeDTO>> GetNodesAsync(AreaQueryDTO input);

    /// <summary>
    /// 获取地区树结构
    /// </summary>
    /// <returns></returns>
    [OperateLog(LogName = "删除地区结构")]
    Task<AppSrvResult> DeleteNodesAsync(AreaTreeNodeDTO[] input);

    /// <summary>
    /// 添加或更新地区列表
    /// </summary>
    /// <returns></returns>
    [OperateLog(LogName = "添加或更新")]
    Task<AppSrvResult<IdDTO[]>> AddOrUpdateRangeAsync(AreaTreeNodeDTO[] input);



    /// <summary>
    /// 删除或更新地区列表
    /// </summary>
    /// <returns></returns>
    [OperateLog(LogName = "删除或更新")]
    Task<AppSrvResult> DeleteOrUpdateRangeAsync(AreaRequestDTO[] input);
}

public interface ICreateAreaCommand
{
    /// <summary>
    /// 新增地区
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [OperateLog(LogName = "新增地区")]
    Task<AppSrvResult<IdDTO>> CreateAsync(AreaRequestDTO input);
}

public interface IDeleteAreaCommand
{
    /// <summary>
    /// 删除地区
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [OperateLog(LogName = "删除地区")]
    Task<AppSrvResult> DeleteAsync(Guid id);
}

public interface IUpdateAreaCommand
{
    /// 修改地区
    /// </summary>
    /// <param name="id"></param>
    /// <param name="input"></param>
    /// <returns></returns>
    [OperateLog(LogName = "修改地区")]
    Task<AppSrvResult> UpdateAsync(AreaRequestDTO input);
}