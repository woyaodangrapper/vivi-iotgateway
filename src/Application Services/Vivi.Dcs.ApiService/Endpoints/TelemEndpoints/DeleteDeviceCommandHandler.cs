﻿using Ardalis.ApiEndpoints;
using MediatR;

namespace Vivi.Dcs.ApiService.Endpoints.TelemEndpoints;

// 设备端点-增删改查分离的中间人设计模式
public record DeviceDelete(string Id) : IRequest<Task<ActionResult>>;

[Route("/endpoints/smart/device")]
public class DeleteDeviceCommandHandler(
  ISmartDeviceAppService smartDeviceAppService,
  ILogger<DeleteDeviceCommandHandler> logger) : EndpointBaseAsync
  .WithRequest<DeviceDelete>
  .WithActionResult<AppSrvResult>
{
    private readonly ISmartDeviceAppService _deviceService = smartDeviceAppService;

    [HttpDelete("delete")]
    [SwaggerOperation(
      Summary = "删除设备",
      Description = "根据设备 ID 删除智能设备",
      OperationId = "Device.Delete",
      Tags = new[] { "Endpoints" })
    ]
    [AllowAnonymous]
    public override async Task<ActionResult<AppSrvResult>> HandleAsync(DeviceDelete request, CancellationToken cancellationToken = default)
    {
        logger.LogInformation("Deleting a device with id {Id}", request.Id);
        return Ok(await _deviceService.DeleteAsync(new(request.Id)));
    }
}