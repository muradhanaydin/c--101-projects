namespace api.Services
{
    public class DBLogger : ILoggerService
    {
        public void Write(string message)
        {
            Console.WriteLine($"[DBLogger] - {message}");
        }
    }
}