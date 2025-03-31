using Vivi.Dcs.Contracts.DTOs.SmartDevice;
using Vivi.SharedKernel.Application.Contracts.Attributes;

namespace Vivi.Dcs.Contracts.IServices;

public interface ISmartDeviceAppService : ICreateDeviceCommand, IDeleteDeviceCommand, IUpdateDeviceCommand, IAppService
{
    /// <summary>
    /// 获取智能设备列表
    /// </summary>
    /// <returns></returns>
    [OperateLog(LogName = "删除智能设备")]
    Task<AppSrvResult<List<DeviceDto>>> GetListAsync();

}

public interface ICreateDeviceCommand
{
    /// <summary>
    /// 新增智能设备
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [OperateLog(LogName = "新增智能设备")]
    Task<AppSrvResult<long>> CreateAsync(DeviceRequestDto input);

}
public interface IDeleteDeviceCommand
{
    /// <summary>
    /// 删除智能设备
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [OperateLog(LogName = "删除智能设备")]
    Task<AppSrvResult> DeleteAsync(Guid id);

}
public interface IUpdateDeviceCommand
{
    /// 修改智能设备
    /// </summary>
    /// <param name="id"></param>
    /// <param name="input"></param>
    /// <returns></returns>
    [OperateLog(LogName = "修改智能设备")]
    Task<AppSrvResult> UpdateAsync(Guid id, DeviceRequestDto input);
}