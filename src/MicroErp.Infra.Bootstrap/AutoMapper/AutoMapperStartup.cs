using System.Reflection;
using MicroErp.Domain.Service.Abstract.Mappers;
using Microsoft.Extensions.DependencyInjection;

namespace MicroErp.Infra.Bootstrap.AutoMapper;

public static class AutoMapperStartup
{
    public static IServiceCollection AddCustomAutoMapper(this IServiceCollection services)
        => services.AddAutoMapper(Assembly.GetAssembly(typeof(BaseAutoMapper)));
}