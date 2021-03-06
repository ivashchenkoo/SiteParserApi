using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SiteParserApi.Services;
using SiteParserApi.Data.Repositories.Abstract;
using SiteParserApi.Data.Repositories.EntityFramework;

namespace SiteParserApi
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            string connectionString = _configuration.GetConnectionString("DefaultConnection");
            services.AddDbContextPool<AppDBContext>(options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
            services.AddTransient<AppDBContext>();
            services.AddTransient<IPostRepository, EFPostRepository>();
            services.AddTransient<IMediaRepository, EFMediaRepository>();
            services.AddTransient<IMediaTypeRepository, EFMediaTypeRepository>();
            services.AddControllers().AddNewtonsoftJson();
            //services.AddHostedService<ParseSitesHostedService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
