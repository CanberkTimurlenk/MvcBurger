using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using MvcBurger.Application.CrossCuttingConcerns.Logging;
using MvcBurger.Application.Exceptions;
using MvcBurger.Web.Models;
using Serilog;


namespace MvcBurger.Web.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IHttpContextAccessor _contextAccessor;

        public ExceptionMiddleware(RequestDelegate next,
            IHttpContextAccessor contextAccessor

             )
        {
            _next = next;
            _contextAccessor = contextAccessor;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }

            catch (Exception exception)
            {
                var exceptionMessages = CreateErrorMessage(context, exception);

                await LogException(context, exceptionMessages);

                HandleExceptionAsync(context, exceptionMessages);
            }
        }

        private IEnumerable<string> CreateErrorMessage(HttpContext context, Exception exception)
        {
            string routeWhereExceptionOccurred = context.Request.Path;

            var path = JsonSerializer.Serialize(routeWhereExceptionOccurred);

            var result = new ErrorViewModel()
            {
                Path = path,
            };

            if (exception is not ICustomException)
                result.ErrorMessages = new List<string> { "Internal Server Error" };
            

            else if (exception is AggregateException ae)
            {
                var messages = ae.InnerExceptions.Select(e => e.Message).ToList();
                result.ErrorMessages = messages;
            }

            else
            {
                string message = exception.Message;
                result.ErrorMessages = new List<string> { message };
            }

            string messagesJson = JsonSerializer.Serialize(result);
            return result.ErrorMessages;
        }

        private Task LogException(HttpContext context, IEnumerable<string> exceptionMessages)
        {

            LogDetailWithException logDetail = new()
            {
                ExceptionMessages = exceptionMessages,
                MethodName = _next.Method.Name,
                User = _contextAccessor.HttpContext?.User.Identity?.Name ?? "-"
            };

            Log.Error("Error during executing at Path: {@RequestPath}, For User: {@User}, Messages: {@Messages}", context.Request.Path.Value, logDetail.User, logDetail.ExceptionMessages);


            return Task.CompletedTask;

        }

        private static void HandleExceptionAsync(HttpContext context, IEnumerable<string> exceptionMessages)
        {

            context.Session.SetString("Errors", JsonSerializer.Serialize(exceptionMessages));

            context.Response.Redirect("/home/error");
        }
    }
}
