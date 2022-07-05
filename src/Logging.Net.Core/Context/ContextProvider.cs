namespace Logging.Net.Core.Context
{
    public class ContextProvider : IContextProvider
    {
        public ContextProvider()
        {
            Context = new LoggerContextFacade();
        }

        public LoggerContextFacade Context { get; }
    }
}
