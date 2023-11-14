using MediatR;
using Microsoft.AspNetCore.Http;
using MvcBurger.Application.Contracts.Services.LogService;
using MvcBurger.Application.CrossCuttingConcerns.Logging;
using System.Text.Json;

namespace MvcBurger.Application.Pipelines.Logging
{
    public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>, ILoggableRequest
    {

        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ILoggerService _loggerService;

        public LoggingBehavior(IHttpContextAccessor httpContextAccessor, ILoggerService loggerService)
        {
            _httpContextAccessor = httpContextAccessor;
            _loggerService = loggerService;
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

            //_loggerServiceBase.Info(JsonSerializer.Serialize(logDetail));
            return await next();
        }
    }
}
