using Microsoft.AspNetCore.Mvc;
using ProblemDetails = Vivi.SharedKernel.Application.Contracts.ResultModels.ProblemDetails;

namespace Ardalis.ApiEndpoints.Expression;

public static class EndpointExtensions
{
    /// <summary>
    /// 封装的 Result 返回逻辑，处理端点成功和失败的返回
    /// </summary>
    /// <typeparam name="TValue">返回类型</typeparam>
    /// <param name="result"></param>
    /// <returns>封装的 ActionResult</returns>
    public static ActionResult<TValue> Build<TValue>(this AppSrvResult<TValue> result)
    {
        if (result.IsSuccess)
        {
            return new ObjectResult(result.Content);
        }

        return Problem(result.ProblemDetails);
    }

    /// <summary>
    /// 封装的 Result 返回逻辑，处理端点成功和失败的返回（无内容）
    /// </summary>
    /// <returns>封装的 ActionResult</returns>
    public static ActionResult Build(this AppSrvResult result)
    {
        if (result.IsSuccess)
        {
            return new NoContentResult();
        }

        return Problem(result.ProblemDetails);
    }

    /// <summary>
    /// 封装的 Problem 返回逻辑
    /// </summary>
    /// <param name="problemDetails"></param>
    /// <returns>封装的 Problem 结果</returns>
    private static ObjectResult Problem(ProblemDetails problemDetails)
    {
        return new ObjectResult(new ProblemDetails
        {
            Detail = problemDetails.Detail,
            Instance = problemDetails.Instance,
            Status = problemDetails.Status,
            Title = problemDetails.Title,
            Type = problemDetails.Type
        })
        {
            StatusCode = problemDetails.Status
        };
    }

    private static ObjectResult Problem(dynamic exception)
    {
        var problemDetails = exception.Content;

        return Problem(problemDetails);
    }
}
