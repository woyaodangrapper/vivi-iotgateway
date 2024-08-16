﻿//------------------------------------------------------------------------------
//  此代码版权声明为全文件覆盖，如有原作者特别声明，会在下方手动补充
//  此代码版权（除特别声明外的代码）归作者本人Diego所有
//  源代码使用协议遵循本仓库的开源协议及附加协议
//  Gitee源代码仓库：https://gitee.com/diego2098/ThingsGateway
//  Github源代码仓库：https://github.com/kimdiego2098/ThingsGateway
//  使用文档：https://kimdiego2098.github.io/
//  QQ群：605534569
//------------------------------------------------------------------------------

#if !Admin
    using CSScriptLib;
    using ThingsGateway.Gateway.Application;
#endif
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;

using ThingsGateway.Admin.Application;
using ThingsGateway.Admin.Razor;
using ThingsGateway.Logging;

using UAParser;

namespace ThingsGateway.Server;

[AppStartup(-99999)]
public class Startup : AppStartup
{
    public void ConfigBlazorServer(IServiceCollection services)
    {
#if !Admin
        services.AddScoped<IGatewayExportService, GatewayExportService>();
#endif
        // 增加网站服务
        AddWebSiteServices(services);
    }

    /// <summary>
    /// 添加网站服务
    /// </summary>
    /// <param name="services"></param>
    private IServiceCollection AddWebSiteServices(IServiceCollection services)
    {


        #region api日志

        //Monitor日志配置
        services.AddMonitorLogging(options =>
        {
            options.JsonIndented = true;// 是否美化 JSON
            options.GlobalEnabled = false;//全局启用
            options.ConfigureLogger((logger, logContext, context) =>
            {
                var httpContext = context.HttpContext;//获取httpContext
                                                      //获取头
                var userAgent = httpContext.Request.Headers["User-Agent"];
                if (string.IsNullOrEmpty(userAgent)) userAgent = "Other";//如果没有这个头就指定一个

                var parser = Parser.GetDefault();
                //获取客户端信息
                var client = parser.Parse(userAgent);
                // 获取控制器/操作描述器
                var controllerActionDescriptor = context.ActionDescriptor as ControllerActionDescriptor;
                //操作名称默认是控制器名加方法名,自定义操作名称要在action上加Description特性
                var option = $"{controllerActionDescriptor.ControllerName}/{controllerActionDescriptor.ActionName}";

                var desc = NetCoreApp.CreateLocalizerByType(controllerActionDescriptor.ControllerTypeInfo.AsType())[controllerActionDescriptor.MethodInfo.Name];
                //获取特性
                option = desc.Value;//则将操作名称赋值为控制器上写的title

                logContext.Set(LoggingConst.CateGory, option);//传操作名称
                logContext.Set(LoggingConst.Operation, option);//传操作名称
                logContext.Set(LoggingConst.Client, client);//客户端信息
                logContext.Set(LoggingConst.Path, httpContext.Request.Path.Value);//请求地址
                logContext.Set(LoggingConst.Method, httpContext.Request.Method);//请求方法
            });
        });
        //日志写入数据库配置
        services.AddDatabaseLogging<DatabaseLoggingWriter>(options =>
        {
            options.WriteFilter = (logMsg) =>
            {
                return logMsg.LogName == "System.Logging.LoggingMonitor";//只写入LoggingMonitor日志
            };
        });

        #endregion api日志


        services.AddSingleton<IUnifyResultProvider, UnifyResultProvider>();
        services.AddSingleton<IAuthService, AuthService>();
        services.AddScoped<IAuthRazorService, AuthRazorService>();
        services.AddSingleton<IAppService, AspNetCoreAppService>();
        services.AddSingleton<IApiPermissionService, ApiPermissionService>();

        services.AddSingleton<IFileService, FileService>();
        services.AddSingleton<IImportExportService, ImportExportService>();

        services.AddSingleton<ISignalrNoticeService, SignalrNoticeService>();
        services.AddSingleton<IAuthService, AuthService>();


        //已添加AddOptions
        // 增加多语言支持配置信息
        services.AddRequestLocalization<IOptionsMonitor<BootstrapBlazor.Components.BootstrapBlazorOptions>>((localizerOption, blazorOption) =>
        {
            blazorOption.OnChange(op => Invoke(op));
            Invoke(blazorOption.CurrentValue);

            void Invoke(BootstrapBlazor.Components.BootstrapBlazorOptions option)
            {
                var supportedCultures = option.GetSupportedCultures();
                localizerOption.SupportedCultures = supportedCultures;
                localizerOption.SupportedUICultures = supportedCultures;
            }
        });

        services.AddScoped<BlazorAppContext>(a =>
        {
            var sysResourceService = a.GetService<ISysResourceService>();
            var userCenterService = a.GetService<IUserCenterService>();
            var userService = a.GetService<ISysUserService>();
            var appContext = new BlazorAppContext(sysResourceService, userCenterService, userService);
#if Admin
            appContext.TitleLocalizer = a.GetRequiredService<IStringLocalizer<ThingsGateway.Admin.Razor.MainLayout>>();
#else
            appContext.TitleLocalizer = a.GetRequiredService<IStringLocalizer<ThingsGateway.Gateway.Razor.MainLayout>>();
#endif

            return appContext;
        });

        services.AddHttpContextAccessor();

        //添加cookie授权
        var authenticationBuilder = services.AddAuthentication(nameof(ThingsGateway)).AddCookie(nameof(ThingsGateway), a =>
         {
             a.AccessDeniedPath = "/Account/AccessDenied/";
             a.LogoutPath = "/Account/Logout/";
             a.LoginPath = "/Account/Login/";
         });

        // 添加jwt授权
        authenticationBuilder.AddJwtBearer(options =>
        {
            var jwtSettings = JWTEncryption.GetJWTSettings();
            // 配置 JWT 验证信息
            options.TokenValidationParameters = JWTEncryption.CreateTokenValidationParameters(jwtSettings);
        });

        services.AddAuthorization();
        services.AddCascadingAuthenticationState();
        services.AddScoped<IAuthorizationHandler, BlazorAuthenticationStateProvider>();

        return services;
    }



}
