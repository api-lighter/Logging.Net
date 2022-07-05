namespace Logging.Net.Core.Context
{
    public interface IContextProvider
    {
        LoggerContextFacade Context { get; }
    }
}
