using System.Reflection;
using ECommerce_TG.Application.SeedWork.PipelineBehaviors;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerce_TG.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationPipelineBehavior<,>));

        return services;
    }
}