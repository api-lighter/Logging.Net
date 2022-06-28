using System.ComponentModel;

namespace Logging.Net.Core.MessageTypes
{
    /// <summary>
    /// Integrated (external) api calls messages
    /// </summary>
    public enum ExternalServiceMessages
    {
        [Description("ExtReq")]
        ExRequest,
        [Description("ExtRes")]
        ExResponse,
    }
}
