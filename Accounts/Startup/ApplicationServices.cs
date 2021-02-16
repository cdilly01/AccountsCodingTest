using Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Web
{
    public static class ApplicationServices
    {
        public static void AddApplicationServices(IServiceCollection services, IConfiguration configuration)
        {
            //base services
            //services.AddScoped(typeof(IBaseServiceDependencies<>), typeof(BaseServiceDependencies<>));
            //services.AddScoped(typeof(IBaseControllerDependencies<>), typeof(BaseControllerDependencies<>));
            //services.AddScoped(typeof(Startup), typeof(Startup));

            services.AddSingleton<IConfiguration>(configuration);
            //services.AddTransient<ITenantProvider, HttpTenantProvider>();

            //application base services
            services.AddScoped(typeof(IFrontierService), typeof(FrontierService));
          
            //TODO: add methods as needed.
            //services.AddDataSources();
            //services.AddSearch();
            //services.AddEditPage();
            //services.AddPackagerDependencies();
        }
    }
}
