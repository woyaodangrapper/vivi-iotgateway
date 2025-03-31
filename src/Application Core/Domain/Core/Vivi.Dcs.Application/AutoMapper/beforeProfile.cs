using Vivi.Dcs.Contracts.DTOs.SmartDevice;

namespace Vivi.Dcs.Application.AutoMapper;

public class beforeProfile : Profile
{
    public beforeProfile()
    {
        CreateMap(typeof(PagedModel<>), typeof(PageModelDto<>)).ForMember("XData", opt => opt.Ignore());

        CreateMap<DeviceDto, SmartDeviceEntity>();
        CreateMap<SmartDeviceEntity, DeviceDto>();

        CreateMap<DeviceRequestDto, SmartDeviceEntity>();
        CreateMap<SmartDeviceEntity, DeviceRequestDto>();
    }
}