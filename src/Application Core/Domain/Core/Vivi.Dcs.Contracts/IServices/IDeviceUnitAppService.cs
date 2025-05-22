using Vivi.Dcs.Contracts.DTOs;
using Vivi.SharedKernel.Contracts.Attributes;

namespace Vivi.Dcs.Contracts.IServices;

public interface IDeviceUnitAppService : ICreateDeviceUnitCommand, IDeleteDeviceUnitCommand, IUpdateDeviceUnitCommand, IAppService
{
    /// <summary>
    /// 获取设备传感器列表
    /// </summary>
    /// <returns></returns>
    [OperateLog(LogName = "查询设备传感器")]
    Task<SearchPage<DeviceUnitDTO>> GetPagedAsync(DeviceUnitQueryDTO input);
}

public interface ICreateDeviceUnitCommand
{
    /// <summary>
    /// 新增设备传感器
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [OperateLog(LogName = "新增设备传感器")]
    Task<AppSrvResult<IdDTO>> CreateAsync(DeviceUnitRequestDTO input);
}

public interface IDeleteDeviceUnitCommand
{
    /// <summary>
    /// 删除设备传感器
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [OperateLog(LogName = "删除设备传感器")]
    Task<AppSrvResult> DeleteAsync(Guid id);
}

public interface IUpdateDeviceUnitCommand
{
    /// 修改设备传感器
    /// </summary>
    /// <param name="id"></param>
    /// <param name="input"></param>
    /// <returns></returns>
    [OperateLog(LogName = "修改设备传感器")]
    Task<AppSrvResult> UpdateAsync(DeviceUnitRequestDTO input);
}