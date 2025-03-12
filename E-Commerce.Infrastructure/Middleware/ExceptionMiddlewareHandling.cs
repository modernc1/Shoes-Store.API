

using E_Commerce.Application.Interfaces.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace E_Commerce.Infrastructure.Middleware;

public class ExceptionMiddlewareHandling(RequestDelegate _next)
{
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (DbUpdateException ex)
        {
            var logger = context.RequestServices.GetRequiredService<IAppLogger<ExceptionMiddlewareHandling>>();
            //in order to context.Response.WriteAsync() to work we need to specify content type
            context.Response.ContentType = "application/json";
            SqlException? innerException = ex.InnerException as SqlException;
            if (innerException != null)
            {
                logger.LogError(innerException, "Sql Exception");
                switch (innerException.Number)
                {
                    case 2627: //Unique Constraint Violation
                        context.Response.StatusCode = StatusCodes.Status409Conflict;
                        await context.Response.WriteAsync("Unique Constraint Violation");
                        break;
                    case 515: //Can't insert null
                        context.Response.StatusCode = StatusCodes.Status400BadRequest;
                        await context.Response.WriteAsync("Can't Insert null");
                        break;

                    case 547: //Foreign Key constraint violation
                        context.Response.StatusCode = StatusCodes.Status409Conflict;
                        await context.Response.WriteAsync("Foreign Key constraint violation");
                        break;
                    default:
                        context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                        await context.Response.WriteAsync("An error occured while saving entity changes");
                        break;
                }
                
            }
            else
            {
                logger.LogError(ex, "Related Entity Framework Core Exception");
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                await context.Response.WriteAsync("An error occured while saving entity changes");
            }
        }
        catch(Exception ex)
        {
            var logger = context.RequestServices.GetRequiredService<IAppLogger<ExceptionMiddlewareHandling>>();
            logger.LogError(ex, "Unknown Exception");
            
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            await context.Response.WriteAsync(ex.Message);
        }
    }
}
