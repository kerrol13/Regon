using Microsoft.Extensions.DependencyInjection;
using Regon.Application.Common;
using Regon.Domain.Repositories;
using Regon.Infrastructure.Repositories;
using Regon.Infrastructure.Storage;
using System;
using System.Collections.Generic;
using System.Text;

namespace Regon.Infrastructure
{
    public static class DependencyInjection
    {
     
            public static IServiceCollection AddInfrastructure(this IServiceCollection services)
            {
                services.AddScoped<ICustomerRepository, CustomerRepository>();

                services.AddScoped<ILocalFileService, LocalFileService>();

                return services;
            }
    }
}
