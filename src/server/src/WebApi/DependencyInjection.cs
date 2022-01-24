using System;
using GitNode.Application.Common.Interfaces;
using GitNode.WebApi.Filters;
using GitNode.WebApi.Policies.Conventions;
using GitNode.WebApi.Policies.Naming;
using GitNode.WebApi.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.OpenApi.Models;

namespace GitNode.WebApi
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddWebApi(this IServiceCollection services)
        {
            services
                .AddControllers(options =>
                {
                    options.Filters.Add(new ApiExceptionFilterAttribute());
                    options.Conventions.Add(new DefaultAuthorizationConvention());
                    options.Conventions.Add(new HyphenCaseRouteConvention());
                })
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.PropertyNamingPolicy = new SnakeCaseNamingPolicy();
                });

            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                            .AllowAnyMethod()
                            .AllowAnyHeader();
                    });
            });

            services.AddSwaggerGen(c =>
            {
                c.EnableAnnotations();
                c.SchemaFilter<NonNullableSchemaFilter>();
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "GitNode", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please insert JWT with Bearer into field",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey
                });
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
            });
            
            services.AddHttpContextAccessor();
            services.TryAddSingleton<ICurrentUserService, CurrentUserService>();
            return services;
        }
    }
}