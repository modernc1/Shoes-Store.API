
using E_Commerce.Application;
using E_Commerce.Application.DependancyInjection;
using E_Commerce.Infrastructure.Data;
using E_Commerce.Infrastructure.DependancyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Serilog;

namespace E_Commerce.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //logger configuration
            Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .WriteTo.File("Log/Log.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();
            builder.Host.UseSerilog();
            Log.Logger.Information("Application is Building");
			////////////////////////


			// Add services to the container.

			builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddApplicationService(builder.Configuration);
            builder.Services.AddInfrastructureService(builder.Configuration);

			//CORS Config
			builder.Services.AddCors(builder =>
            {
                builder.AddDefaultPolicy(options =>
                {
                    options.AllowAnyHeader();
                    options.AllowAnyMethod();
                    options.AllowAnyOrigin();
                });
            });

            try
            {
                var app = builder.Build();
                //CORS Config
                app.UseCors();

                app.UseSerilogRequestLogging();
                // Configure the HTTP request pipeline.
                if (app.Environment.IsDevelopment())
                {
                    app.UseSwagger();
                    app.UseSwaggerUI();
                }

				using (var scope = app.Services.CreateScope())
				{
					var services = scope.ServiceProvider;
					try
					{
						var context = services.GetRequiredService<AppDbContext>();
						context.Database.Migrate(); // Applies migrations automatically
					}
					catch (Exception ex)
					{
						var logger = services.GetRequiredService<ILogger<Program>>();
						logger.LogError(ex, "An error occurred while applying migrations.");
					}
				}


				app.UseInfrastructureMiddlewares();
                app.UseHttpsRedirection();
                app.UseAuthorization();
                app.UseMiddleware<CurrentUserMiddleware>();

                app.UseStaticFiles(new StaticFileOptions
                {
                    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "Images")),
                    RequestPath = "/Images"
                });

                app.MapControllers();

                Log.Logger.Information("Application is Running ...");
                app.Run();
            }catch (Exception ex)
            {
                Log.Logger.Error(ex, "Application Failed to start ...");
            }
            finally
            {
                Log.CloseAndFlush();
            }
            
        }
    }
}
