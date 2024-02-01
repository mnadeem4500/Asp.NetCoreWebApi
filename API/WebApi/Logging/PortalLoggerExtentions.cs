using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExtremeClassified.WebApi.Logging
{
    public static class PortalLoggerExtentions
    {
        public static IServiceCollection AddPortalLogger(this IServiceCollection services)
        {
            services.AddSingleton<ILoggerProvider, PortalLoggerProvider>();
           // services.Configure(configure);

            return services;
        }
    }
}
