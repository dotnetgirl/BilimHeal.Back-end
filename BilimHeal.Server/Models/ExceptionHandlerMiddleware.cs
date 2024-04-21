﻿using BilimHeal.Server.Service.Commons.Exceptions;

namespace BilimHeal.Server.API.Models
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger<ExceptionHandlerMiddleware> logger;

        public ExceptionHandlerMiddleware(RequestDelegate next, ILogger<ExceptionHandlerMiddleware> logger)
        {
            this.next = next;
            this.logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (CustomException ex)
            {
                context.Response.StatusCode = ex.statusCode;
                await context.Response.WriteAsJsonAsync(new Response
                {
                    Code = ex.statusCode,
                    Message = ex.Message
                });
            }
            catch (Exception ex)
            {
                this.logger.LogError($"{ex}\n\n");
                context.Response.StatusCode = 500;
                await context.Response.WriteAsJsonAsync(new Response
                {
                    Code = 500,
                    Message = ex.Message
                });
            }
        }
    }
}
