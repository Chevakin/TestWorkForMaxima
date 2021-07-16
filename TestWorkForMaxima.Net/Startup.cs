using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using TestWorkForMaxima.Domain.Extensions;
using TestWorkForMaxima.Domain.Interfaces;
using TestWorkForMaxima.Domain.Services;
using TestWorkForMaxima.Domain.Services.Interfaces;

namespace TestWorkForMaxima.Net
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //technical
            services.AddControllersWithViews();

            //common
            services.AddTransient<ICalculatorService, CalculatorService>();
            services.AddArithmeticOperations();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCustomConcurrencyLimiter(Configuration.GetMaxConcurrentRequest());

            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
