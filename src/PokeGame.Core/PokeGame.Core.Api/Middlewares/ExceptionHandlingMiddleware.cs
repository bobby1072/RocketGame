﻿using System.Net;
using System.Net.Mime;
using BT.Common.Api.Helpers;
using BT.Common.Api.Helpers.Models;
using BT.Common.OperationTimer.Common;
using PokeGame.Core.Common;
using PokeGame.Core.Common.Exceptions;

namespace PokeGame.Core.Api.Middlewares;

internal sealed class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context, ILogger<ExceptionHandlingMiddleware> logger)
    {
        try
        {
            try
            {
                try
                {
                    await _next.Invoke(context);
                }
                catch (OperationTimerException ex)
                {
                    throw ex.InnerException ?? ex;
                }
            }
            catch (PokeGameApiUserException exception)
            {
                logger.Log(exception.LogLevel, exception,
                    "A PokeGame exception of type: {ExceptionName} was thrown during request with status code: {StatusCode}",
                    nameof(PokeGameApiUserException),
                    exception.StatusCode);

                await SendExceptionResponseAsync(context, exception.Message, (int)exception.StatusCode);
            }
            catch (PokeGameApiServerException exception)
            {
                logger.Log(exception.LogLevel, exception,
                    "A PokeGame exception of type: {ExceptionName} was thrown during request with status code: {StatusCode}",
                    nameof(PokeGameApiServerException),
                    exception.StatusCode);

                await SendExceptionResponseAsync(context, Constants.ExceptionConstants.InternalError, (int)exception.StatusCode);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Unhandled exception occured during request");

                await SendExceptionResponseAsync(context, Constants.ExceptionConstants.InternalError,
                    (int)HttpStatusCode.InternalServerError);
            }
        }
        catch
        {
            //No need for anymore handling
        }
    }

    private static async Task SendExceptionResponseAsync(HttpContext context, string message, int statusCode)
    {
        var foundCorrelationId = context.Response.Headers[ApiConstants.CorrelationIdHeader].ToString();
        context.Response.Clear();
        context.Response.ContentType = MediaTypeNames.Application.Json;
        context.Response.StatusCode = statusCode;


        if (!string.IsNullOrEmpty(foundCorrelationId))
        {
            context.Response.Headers.TryAdd(ApiConstants.CorrelationIdHeader, foundCorrelationId);
        }
        
        await context.Response.WriteAsJsonAsync(new WebOutcome { ExceptionMessage = message });
    }
}