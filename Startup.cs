using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Cors.Demo
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(mvcOptions => mvcOptions.EnableEndpointRouting = false);
            services.AddCors(corsOptions =>
            {
                corsOptions.AddDefaultPolicy(configurePolicy =>
                {
                    configurePolicy
                        .WithOrigins("https://www.google.com", "https://yandex.ru", "https://github.com/")
                        .WithHeaders("Content-Type");
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
