namespace Vivi.Dcs.Application.AutoMapper;

public class beforeProfile : Profile
{
    public beforeProfile()
    {
        CreateMap(typeof(PagedModel<>), typeof(PageModelDto<>)).ForMember("XData", opt => opt.Ignore());

        CreateMap<DeviceDto, DeviceEntity>();
        CreateMap<DeviceEntity, DeviceDto>();

        CreateMap<DeviceRequestDto, DeviceEntity>();
        CreateMap<DeviceEntity, DeviceRequestDto>();
    }
}