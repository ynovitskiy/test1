using Company.Api.Logic.Core;
using Company.Api.Logic.Services;
using Company.DataProviders.Core;
using Company.DataProviders.Providers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Company.Api
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
            services.AddMvcCore(opt =>
            {
                opt.EnableEndpointRouting = false;
            });

            services.AddControllersWithViews();

            services.AddControllers();

            services.AddLogging();

            services.AddMemoryCache();

            services.AddScoped<IAirportDataProvider, RestAirportDataProvider>();
            services.AddScoped<AirportDataProviderDecorator, CachedDataProviderDecorator>();

            services.AddScoped<IMeasureService, MeasureService>();
            services.AddScoped<MeasureServiceDecorator, CachedMeasureServiceDecorator>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseExceptionHandler("/error");

            app.UseRouting();
            
            app.UseAuthorization();

            app.UseMvc(c => c.MapRoute("default", "{controller=Home}/{action=Index}/{id?}"));

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }

    
}
