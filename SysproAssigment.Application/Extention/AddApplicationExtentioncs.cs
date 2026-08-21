using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SysproAssigment.Application.Behaviour;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace SysproAssigment.Application.Extention
{
    public static class AddApplicationExtentioncs
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(cfg => { }, typeof(Mapper.AutoMapper));
            services.AddMediatR(cg =>
            {
                cg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly());
                services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

                services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
               
            });
            return services;
        }
    }
}
