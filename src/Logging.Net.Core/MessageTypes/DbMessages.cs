using System.ComponentModel;

namespace Logging.Net.Core.MessageTypes
{
    /// <summary>
    /// Database (or any other storage) requests
    /// </summary>
    public enum DbMessages
    {
        [Description("DbReq")]
        DbRequest,
        [Description("DbResp")]
        DbResponse
    }
}
