namespace Vivi.Dcs.Application.AutoMapper;

public class beforeProfile : Profile
{
    public beforeProfile()
    {
        CreateMap<DeviceDTO, DeviceEntity>();
        CreateMap<DeviceEntity, DeviceDTO>();
        CreateMap<DeviceRequestDTO, DeviceEntity>();
        CreateMap<DeviceEntity, DeviceRequestDTO>();

        CreateMap<AreaDTO, AreaEntity>();
        CreateMap<AreaEntity, AreaDTO>();
        CreateMap<AreaRequestDTO, AreaEntity>();
        CreateMap<AreaEntity, AreaRequestDTO>();
    }
}