namespace Vivi.SharedKernel.Application.Contracts.DTOs;

[Serializable]
public abstract class OutputDTO : IDTO
{
    public virtual Guid Id { get; set; }
}