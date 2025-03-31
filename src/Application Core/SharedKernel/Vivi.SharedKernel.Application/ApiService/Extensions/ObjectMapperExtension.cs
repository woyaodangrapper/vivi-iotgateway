namespace Vivi.Infrastructure.Mapper;

public static class ObjectMapperExtension
{
    public static TDestination Map<TDestination>(this IObjectMapper mapper, object source, Guid id)
        where TDestination : Entity
    {
        var destination = mapper.Map<TDestination>(source);
        destination.Id = id;
        return destination;
    }
}
