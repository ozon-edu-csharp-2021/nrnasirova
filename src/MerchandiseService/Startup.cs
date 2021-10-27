using MerchandiseService.Infrastructure.Filters;
using MerchandiseService.Infrastructure.Middlewares;
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
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRouting();
            app.UseEndpoints(endpoints => { });
            app.Map("/version", builder => builder.UseMiddleware<VersionMiddleware>());
            app.Map("/ready", builder => builder.UseMiddleware<ReadyMiddleware>());
            app.Map("/live", builder => builder.UseMiddleware<LiveMiddleware>());
            app.UseMiddleware<RequestLoggingMiddleware>();
            app.UseMiddleware<ResponseLoggingMiddleware>();
        }
    }
}