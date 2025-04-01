using Vivi.Infrastructure.Core.Guard;
using ProblemDetails = Vivi.SharedKernel.Application.Contracts.ResultModels.ProblemDetails;

namespace Vivi.SharedKernel.Application.Services;

public abstract class AbstractAppService : IAppService
{
    protected AppSrvResult AppSrvResult() => new();

    protected AppSrvResult<TValue> AppSrvResult<TValue>(TValue value)
    {
        Checker.Argument.IsNotNull(value, nameof(value));
        return new AppSrvResult<TValue>(value);
    }

    protected ProblemDetails Problem(HttpStatusCode? statusCode = null, string? detail = null, string? title = null, string? instance = null, string? type = null) => new(statusCode, detail, title, instance, type);

    protected Expression<Func<TEntity, object>>[] UpdatingProps<TEntity>(params Expression<Func<TEntity, object>>[] expressions) => expressions;

}