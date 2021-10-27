using MerchandiseService.Infrastructure.Filters;
using MerchandiseService.Infrastructure.Interceptors;
using MerchandiseService.Infrastructure.Middlewares;
using MerchandiseService.Infrastructure.StartupFilters;
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
            services.AddControllers(options => options.Filters.Add<GlobalExceptionFilter>());
            services.AddGrpc(options => options.Interceptors.Add<LoggingInterceptor>());
            services.AddSingleton<IStartupFilter, SwaggerStartupFilter>();
            services.AddSingleton<IStartupFilter, TerminalStartupFilter>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRouting();
            app.UseEndpoints(endpoints => { });
        }
    }
}