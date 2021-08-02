using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sistema_Incidentes.Configuration;

namespace Sistema_Incidentes
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSwaggerConfig();
            services.AddWebApiConfiguration(MyAllowSpecificOrigins);
            services.AddContextConfiguration(Configuration);
            services.ResolveDependencies();
            services.AddJwtConfiguration(Configuration);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IApiVersionDescriptionProvider provider)
        {
            //if (env.IsDevelopment())
            //{
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
            //}
            
            app.UseStaticFiles();
            app.UseWebApiConfiguration(MyAllowSpecificOrigins);
            app.UseSwaggerConfig(env, provider);
        }
    }
}
