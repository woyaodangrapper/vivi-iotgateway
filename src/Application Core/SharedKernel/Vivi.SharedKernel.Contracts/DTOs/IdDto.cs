namespace Vivi.SharedKernel.Application.Contracts.DTOs;

[Serializable]
public sealed class IdDTO : OutputDTO
{
    public IdDTO()
    {
    }

    public IdDTO(Guid id)
    {
        Id = id;
    }
}