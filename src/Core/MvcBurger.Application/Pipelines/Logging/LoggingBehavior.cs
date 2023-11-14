using MediatR;
using Microsoft.AspNetCore.Http;

using MvcBurger.Application.CrossCuttingConcerns.Logging;
using MvcBurger.Application.CrossCuttingConcerns.Logging.Serilog;
using System.Text.Json;

namespace MvcBurger.Application.Pipelines.Logging
{
    public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>, ILoggableRequest
    {

        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly LoggerBase _loggerBase;

        public LoggingBehavior(IHttpContextAccessor httpContextAccessor, LoggerBase loggerBase)
        {
            _httpContextAccessor = httpContextAccessor;
            _loggerBase = loggerBase;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            List<LogParameter> logParameters =
                new()
                {
                new LogParameter{Type= request.GetType().Name, Value= request },
                };

            LogDetail logDetail
                = new()
                {
                    MethodName = next.Method.Name,
                    Parameters = logParameters,
                    User = _httpContextAccessor.HttpContext.User.Identity?.Name ?? "?"
                };

            _loggerBase.Info(JsonSerializer.Serialize(logDetail));
            return await next();
        }
    }
}
