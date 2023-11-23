namespace MvcBurger.Application.CrossCuttingConcerns.Logging
{
    public class LogDetailWithException : LogDetail
    {
        public IEnumerable<string> ExceptionMessages { get; set; }
        public LogDetailWithException()
        {
            ExceptionMessages = Enumerable.Empty<string>();
        }

        public LogDetailWithException(
            string fullName,
            string methodName,
            string user,
            List<LogParameter> parameters,
            IEnumerable<string> exceptionMessages) : base(fullName, methodName, user, parameters)
        {
            ExceptionMessages = exceptionMessages;
        }
    }
}

