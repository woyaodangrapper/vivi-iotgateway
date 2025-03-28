namespace Vivi.Dcs.Application.AutoMapper;

public class beforeProfile : Profile
{
    public beforeProfile()
    {
        CreateMap(typeof(PagedModel<>), typeof(PageModelDto<>)).ForMember("XData", opt => opt.Ignore());
    }
}