using Microsoft.AspNetCore.Mvc.Filters;

namespace Vivi.SharedKernel.Application.Filters;

/// <summary>
/// API响应拦截器，统一封装非错误的返回
/// </summary>
public sealed class ApiResponseInterceptorAttribute : ActionFilterAttribute
{
    private readonly ILogger<ApiResponseInterceptorAttribute> _logger;

    public ApiResponseInterceptorAttribute(ILogger<ApiResponseInterceptorAttribute> logger)
    {
        _logger = logger;
    }

    public override void OnActionExecuted(ActionExecutedContext context)
    {
        base.OnActionExecuted(context);

        // 获取 Action 返回值
        if (context.Result is ObjectResult objectResult)
        {
            // 如果返回数据是成功的
            if (objectResult.StatusCode >= 200 && objectResult.StatusCode < 300)
            {
                // 封装成功响应体
                var result = objectResult.Value;
                objectResult.Value = new
                {
                    code = "0",  // 成功的错误码，统一设为 0 或自定义值
                    msg = "success",      // 成功信息
                    data = result         // 原始数据
                };
            }
        }
        else if (context.Result is JsonResult jsonResult)
        {
            // 如果返回是 JsonResult，也进行类似封装
            var result = jsonResult.Value;
            jsonResult.Value = new
            {
                code = "0",
                msg = "success",
                data = result
            };
        }
    }
}
