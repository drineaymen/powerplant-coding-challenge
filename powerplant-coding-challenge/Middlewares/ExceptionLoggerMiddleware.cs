using System;
using System.Net;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Text;
using powerplant_coding_challenge.Controllers;

namespace powerplant_coding_challenge.Middlewares
{
	public class ExceptionLoggerMiddleware
	{
        private readonly RequestDelegate _next;
        private readonly ILogger<ProductionPlanController> _logger;

        public ExceptionLoggerMiddleware(RequestDelegate next, ILogger<ProductionPlanController> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context, IServiceProvider serviceProvider)
        {

            try
            {
                await _next(context);
            }
            catch (ArgumentNullException e)
            {
                await WriteResponseAsync(context, e, HttpStatusCode.BadRequest);
            }
            catch (InvalidOperationException e)
            {
                await WriteResponseAsync(context, e, HttpStatusCode.UnprocessableEntity);
            }
            catch (Exception e)
            {
                await WriteResponseAsync(context, e, HttpStatusCode.InternalServerError);
            }
        }

        private async Task WriteResponseAsync(HttpContext context, Exception e, HttpStatusCode statusCode)
        {
            _logger.LogError($"Some thing went wrong: {e.Message}{Environment.NewLine}{e.StackTrace}");

            context.Response.StatusCode = (int)statusCode;
            await context.Response.Body.WriteAsync(Encoding.UTF8.GetBytes("Some thing went wrong"));
        }
    }
}

