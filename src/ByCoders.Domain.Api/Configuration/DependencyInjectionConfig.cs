using ByCoders.Core.Identity;
using ByCoders.Domain.Api.Commands;
using ByCoders.Domain.Api.Data;
using ByCoders.Domain.Api.Repositories;
using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using static ByCoders.Domain.Api.Commands.AddCNABCommand;

namespace ByCoders.Domain.Api.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IAspNetUser, AspNetUser>();
            services.AddScoped<ITituloRepository, TituloRepository>();
            services.AddScoped<IRequestHandler<AddCNABCommand, ValidationResult>, AddCNABCommandHandler>();
            services.AddScoped<ByCodersDBContext>();

        }
    }
}
