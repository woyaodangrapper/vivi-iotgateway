using MediatR;
using Vivi.Dcs.Contracts;

namespace Vivi.Dcs.Application.Commands;

[Serializable]
public class BaseCommand : BaseCommand<Unit>, ICommand, IRequest
{
}

[Serializable]
public class BaseCommand<TResult> : ICommand<TResult>, IRequest<TResult>
{
}