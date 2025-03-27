namespace Vivi.Dcs.Application.AutoMapper;

public class DcsProfile : Profile
{
    public DcsProfile()
    {
        CreateMap(typeof(PagedModel<>), typeof(PageModelDto<>)).ForMember("XData", opt => opt.Ignore());
    }
}