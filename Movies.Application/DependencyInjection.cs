using Microsoft.Extensions.DependencyInjection;
using Movies.Application.Mappings;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mapster;
using System.Reflection;

namespace Movies.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(cf => cf.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            MapingConfig.configure();

            var config = TypeAdapterConfig.GlobalSettings;
            config.Scan(Assembly.GetExecutingAssembly());

            services.AddSingleton(config);
            return services;
        }
    }
}