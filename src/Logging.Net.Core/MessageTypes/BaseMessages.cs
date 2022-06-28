using System.ComponentModel;

namespace Logging.Net.Core.MessageTypes
{
    /// <summary>
    /// Base log message types
    /// </summary>
    public enum BaseMessages
    {
        Fatal,
        [Description("Svc")]
        Service,
        [Description("Bsn")]
        BusinessLogic,
        Error
    };
}
