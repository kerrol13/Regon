using Microsoft.Extensions.DependencyInjection;
using Regon.Application.Interfaces;
using Regon.Application.Services;

namespace Regon.Application
{
    public static class DependencyInjection
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddScoped<ICustomerService, CustomerService>();
        }
    }
}
