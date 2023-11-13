namespace ConsoleApplication.NewFolder
{
    public record CreateAppUserResponse
    {
        public bool Succeeded { get; init; }
        public string Message { get; init; }
    }
}
