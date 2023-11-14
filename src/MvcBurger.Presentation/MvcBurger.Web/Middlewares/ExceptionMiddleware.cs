using System.Text.Json;
using MvcBurger.Application.CrossCuttingConcerns.Logging;
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
                var exceptionMessages = AddErrorMessagesToContext(context, exception);

                await LogException(context, exception, exceptionMessages);

                await HandleExceptionAsync(context);
            }
        }

        private IEnumerable<string> AddErrorMessagesToContext(HttpContext context, Exception exception)
        {
            string routeWhereExceptionOccurred = context.Request.Path;

            var path = JsonSerializer.Serialize(routeWhereExceptionOccurred);

            var result = new ErrorViewModel()
            {
                Path = path,
            };

            if (exception is AggregateException ae)
            {
                var messages = ae.InnerExceptions.Select(e => e.Message).ToList();
                result.ErrorMessages = messages;
                string messagesJson = JsonSerializer.Serialize(result);
                context.Items["ErrorMessages"] = messagesJson;
            }

            else
            {
                string message = exception.Message;
                result.ErrorMessages = new List<string> { message };

                string messagesJson = JsonSerializer.Serialize(result);
                context.Items["ErrorMessages"] = messagesJson;
            }
            return result.ErrorMessages;
        }

        private Task LogException(HttpContext context, Exception exception, IEnumerable<string> exceptionMessages)
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

        private static async Task HandleExceptionAsync(HttpContext context)
        {
            string messagesAsJson = context.Items["ErrorMessages"] as string;
            string redirectUrl = $"/Home/Error?messagesJson={messagesAsJson}";

            context.Response.Redirect(redirectUrl);
        }
    }
}