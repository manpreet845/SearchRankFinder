namespace SearchRankFinder.Core.Logging
{
    public class Logger : ILogger
    {
        public void Log(string message, LogLevel logLevel)
        {
            // Ideally this would log externally, but for the purpose of this 
            // demo we will log to console.
            Console.Out.WriteLine($"{logLevel} - {message}");
        }

        public void Log(string message, LogLevel logLevel, Exception exception)
        {
            Log($"{message}: {exception.Message}", logLevel);
        }
    }
}
