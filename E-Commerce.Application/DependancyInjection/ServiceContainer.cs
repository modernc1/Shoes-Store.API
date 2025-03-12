

using E_Commerce.Application.Mapping;
using E_Commerce.Application.Secrets;
using E_Commerce.Application.Validations.Authentication;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace E_Commerce.Application.DependancyInjection
{
    public static class ServiceContainer
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services, IConfiguration configuration)
        {
            var thisAssembly = typeof(ServiceContainer).Assembly;
            services.AddAutoMapper(thisAssembly);
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(thisAssembly));

            services.AddFluentValidationAutoValidation();
            services.AddValidatorsFromAssemblyContaining<CreateUserCommandValidation>();// as nmae of function this well add all validation in the same assembly of CreateUserValidation.cs

			var tapConfiguration = new TapConfiguration();
			configuration.GetSection("TapPayment").Bind(tapConfiguration);

			// Register it as a singleton
			services.AddSingleton(tapConfiguration);


			return services;
        }
    }
}
