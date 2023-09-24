using GameLibraryApi.Common.Exceptions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Text.Json;
using System.Threading.Tasks;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionMiddleware> _logger;

    public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (CustomException ex)
        {
            await HandleException(context, ex);
        }
        catch (Exception ex)
        {
            await HandleException(context, ex);
        }
    }

    private async Task HandleException(HttpContext context, Exception ex)
    {
        context.Response.ContentType = "application/json";
        string error = "";

        _logger.LogError("Error : {0}" +
            "\n      Method: {1}" +
            "\n      Path: {2}", ex.Message, context.Request.Method, context.Request.Path);

        // Hata mesajını istemciye döndür
        if (ex is CustomException customException)
        {
            context.Response.StatusCode = customException.ErrorCode;
            error = customException.Error;
        }
        else
        {
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            error = "Internal Server Error";
        }

        var response = new { status = context.Response.StatusCode, error, message = ex.Message };
        var jsonResponse = JsonSerializer.Serialize(response);

        await context.Response.WriteAsync(jsonResponse);

    }
}

public static class ExceptionMiddlewareExtensions
{
    public static IApplicationBuilder UseExceptionMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ExceptionMiddleware>();
    }
}
