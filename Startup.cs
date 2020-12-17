using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Cors.Demo
{
    public class Startup
    {
        private readonly IConfiguration _config;

        public Startup(IConfiguration config) => _config = config;

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(mvcOptions => mvcOptions.EnableEndpointRouting = false);
            services.AddCors(corsOptions =>
            {
                corsOptions.AddDefaultPolicy(configurePolicy =>
                {
                    configurePolicy
                        .WithOrigins(_config.GetSection("AllowedCorsOrigins").Get<string[]>())
                        .WithHeaders(_config.GetSection("AllowedRequestHeaders").Get<string[]>());
                });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors();
            app.UseMvc(configureRoutes => {
                configureRoutes.MapRoute(
                    name: "DefaultRoute",
                    template: "{controller}/{action}",
                    defaults: new { controller = "HappyNewYear", action = "HowLongUntilNewYear" }
                );
            });
        }
    }
}
