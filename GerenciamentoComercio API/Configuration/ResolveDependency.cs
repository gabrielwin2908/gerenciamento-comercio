using GerenciamentoComercio_Domain;
using GerenciamentoComercio_Domain.Interfaces;
using GerenciamentoComercio_Domain.v1.Interfaces.Repositories;
using GerenciamentoComercio_Domain.v1.Interfaces.Services;
using GerenciamentoComercio_Domain.v1.Repositories;
using GerenciamentoComercio_Domain.v1.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Sistema_Incidentes.Configuration
{
    public static class DependencyConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            //Work Interfaces
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
            services.AddScoped<IAuthenticatedUser, AuthenticatedUser>();

            //Repositories
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();


            // Services
            services.AddScoped<IAuthenticationServices, AuthenticationService>();

            return services;
        }
    }
}

