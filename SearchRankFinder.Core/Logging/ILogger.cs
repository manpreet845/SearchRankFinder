namespace SearchRankFinder.Core.Logging;

public interface ILogger
{
    void Log(string message, LogLevel logLevel);
    void Log(string message, LogLevel logLevel, Exception exception);
}