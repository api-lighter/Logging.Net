using System.ComponentModel;

namespace Logging.Net.Core.MessageTypes
{

    /// <summary>
    /// Event queue (message queue) messages types
    /// Aka. `consuming` or `publishing`
    /// </summary>
    public enum EventQueueMessages
    {
        [Description("EqPub")]
        EqPublish,
        [Description("EqCons")]
        EqConsume
    }
}
