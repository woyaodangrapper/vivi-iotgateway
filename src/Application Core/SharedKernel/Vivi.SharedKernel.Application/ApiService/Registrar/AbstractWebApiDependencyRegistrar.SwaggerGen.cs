﻿using Vivi.SharedKernel.Application.Extensions;

namespace Vivi.SharedKernel.ApiService.Registrar;

public abstract partial class AbstractWebApiDependencyRegistrar
{
    /// <summary>
    /// 注册swagger组件
    /// </summary>
    protected virtual void AddSwaggerGen()
    {
        var openApiInfo = new OpenApiInfo { Title = ServiceInfo.ShortName, Version = ServiceInfo.Version };
        Services.AddEndpointsApiExplorer();
        Services
            .AddSwaggerGen(c =>
            {
                c.SwaggerDoc(openApiInfo.Version, openApiInfo);
                // 启用 Swagger 的注解支持
                c.EnableAnnotations();
                // 采用bearer token认证
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme."
                });
                //设置全局认证
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        Array.Empty<string>()
                    }
                });

                c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, $"{ServiceInfo.StartAssembly.GetName().Name}.xml"), true);
                c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, $"{ServiceInfo.StartAssembly.GetName().Name?.Replace("ApiService", "Contracts")}.xml"), true);
            })
            .AddSimpleFluentValidation();
        //.AddFluentValidationRulesToSwagger();
    }
}