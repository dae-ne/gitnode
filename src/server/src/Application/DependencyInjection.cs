﻿using System.Reflection;
using FluentValidation;
using GitNode.Application.Common.Behaviours;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace GitNode.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            var executingAssembly = Assembly.GetExecutingAssembly();
            return services
                .AddMediatR(executingAssembly)
                .AddValidatorsFromAssembly(executingAssembly)
                .AddAutoMapper(executingAssembly)
                .AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
        }
    }
}
