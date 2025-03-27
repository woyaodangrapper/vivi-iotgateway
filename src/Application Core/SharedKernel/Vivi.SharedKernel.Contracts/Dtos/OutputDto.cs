namespace Vivi.SharedKernel.Application.Contracts.Dtos;

[Serializable]
public abstract class OutputDto : IDto
{
    public virtual long Id { get; set; }
}