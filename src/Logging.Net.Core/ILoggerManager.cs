namespace Logging.Net.Core
{
    public interface ILoggerManager
    {
        ILoggerBase GetLogger(string loggerName);
        ILoggerBase GetLogger<T>();
    }
}
