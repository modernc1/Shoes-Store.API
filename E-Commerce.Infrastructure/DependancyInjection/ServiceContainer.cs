
using E_Commerce.Infrastructure.Data;
using E_Commerce.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using EntityFramework.Exceptions.SqlServer;
using Microsoft.AspNetCore.Builder;
using E_Commerce.Infrastructure.Middleware;
using E_Commerce.Infrastructure.Services;
using E_Commerce.Domain.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using E_Commerce.Domain.Interfaces.Authentication;
using E_Commerce.Infrastructure.Repositories.Authentication;
using E_Commerce.Domain.Interfaces.Repositories;
using E_Commerce.Infrastructure.Implementations.Repositories;
using E_Commerce.Application.Interfaces.Logging;
using E_Commerce.Infrastructure.Implementations.Authentication;
using E_Commerce.Infrastructure.Implementations.Repositories.Cart;
using E_Commerce.Domain.Interfaces.Repositories.Cart;
using E_Commerce.Application.Interfaces.Stripe;
namespace E_Commerce.Infrastructure.DependancyInjection
{
    public static class ServiceContainer
    {
        public static IServiceCollection AddInfrastructureService(this IServiceCollection services, IConfiguration configuration)
        {
            string DefaultConnectionString = "Default";
            services.AddDbContext<AppDbContext>(
                options =>
                options.UseSqlServer(
                    configuration.GetConnectionString(DefaultConnectionString),
                    sqlServeOptions =>
                    { //Ensure this is correct assymbly
                        sqlServeOptions.MigrationsAssembly(typeof(ServiceContainer).Assembly.FullName);
                        sqlServeOptions.EnableRetryOnFailure(); //Enable automatic retry when failure
                    }).UseExceptionProcessor(), //this method come from this package EntityFramework.Exceptions.SqlServer;,
                    ServiceLifetime.Scoped);

            var sss = configuration.GetConnectionString(DefaultConnectionString);
			//Register Interfaces
			services.AddScoped<IGeneric<Product>, GenericRepository<Product>>();
            
            services.AddScoped<IGeneric<Color>, GenericRepository<Color>>();
            services.AddScoped<IGeneric<SizeOption>, GenericRepository<SizeOption>>();
            services.AddScoped<IGeneric<ProductVariation>, GenericRepository<ProductVariation>>();

            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductItemRepository, ProductItemRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped(typeof(IAppLogger<>), typeof(SerilogLoggerAdapter<>));// logger intiation must be added to program.cs at top
            services.AddScoped<IPaymentMethodRepository, PaymentMethodRepository>();
            services.AddScoped<IStripePaymentService, StripePaymentService>();
            services.AddScoped<ICartRepository, CartRepository>();
            services.AddHttpContextAccessor();
            Stripe.StripeConfiguration.ApiKey = configuration["Stripe:SecretKey"];
            //identity configuration
            services.AddDefaultIdentity<AppUser>(options =>
            {
                options.SignIn.RequireConfirmedEmail = false;
                options.Tokens.EmailConfirmationTokenProvider = TokenOptions.DefaultEmailProvider;
                options.Password.RequiredLength = 8;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
            })
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<AppDbContext>(); //then we go to 

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(options =>
                {
                    options.SaveToken = true;
                    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                    {
                        ValidateAudience = true,//Audience is The User
                        ValidateIssuer = true, //Issuer is the Server
                        ValidateLifetime = true,//To know if token is expired or not
                        RequireExpirationTime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = configuration["JWT:Issuer"],
                        ValidAudience = configuration["JWT:Audience"],
                        ClockSkew = TimeSpan.Zero,//To make time between server and client the same
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Key"]!))
                    };
                });

            services.AddScoped<IUserManagement, UserManagement>();
            services.AddScoped<ITokenManagement, TokenManagement>();
            services.AddScoped<IRoleManagement, RoleManagement>();

            return services;
        }


        public static IApplicationBuilder UseInfrastructureMiddlewares(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddlewareHandling>();

            return app;
        }
    }


}
