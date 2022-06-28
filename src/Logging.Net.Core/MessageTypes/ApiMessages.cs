using System.ComponentModel;

namespace Logging.Net.Core.MessageTypes
{
    /// <summary>
    /// Api request/response messages
    /// </summary>
    public enum ApiMessages
    {
        [Description("Req")]
        ApiRequest,
        [Description("Res")]
        ApiResponse
    }
}
