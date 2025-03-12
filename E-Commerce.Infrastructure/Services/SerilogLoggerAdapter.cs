using Microsoft.Extensions.Logging;
using E_Commerce.Application.Interfaces.Logging;

namespace E_Commerce.Infrastructure.Services
{
    internal class SerilogLoggerAdapter<T>(ILogger<T> logger) : IAppLogger<T>
    {
        public void LogError(Exception ex, string message) => logger.LogError(ex, message);
        

        public void LogInformation(string message) => logger.LogInformation(message);


        public void LogWarning(string message) => logger.LogWarning(message);
        
    }
}
