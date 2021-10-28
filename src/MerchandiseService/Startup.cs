using MerchandiseService.GrpcServices;
using MerchandiseService.Infrastructure.Filters;
using MerchandiseService.Infrastructure.Interceptors;
using MerchandiseService.Infrastructure.Middlewares;
using MerchandiseService.Infrastructure.StartupFilters;
using MerchandiseService.Services;
using MerchandiseService.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace MerchandiseService
{
    public class Startup
    {
        public Startup()
        {
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddGrpc(options => options.Interceptors.Add<LoggingInterceptor>());
            services.AddSingleton<IMerchService, MerchService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGrpcService<MerchGrpcService>();
                endpoints.MapControllers();
            });
        }
    }
}