namespace Vivi.Dcs.Contracts;

public interface ICommand
{
}

public interface ICommand<out TResponse> : ICommand
{
}