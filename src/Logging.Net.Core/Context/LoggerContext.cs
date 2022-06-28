using System;

namespace Logging.Net.Core.Context
{
    public class LoggerContext
    {
        public Guid RequestId { get; set; }
        public string User { get; set; }
        public string OperationId { get; set; }
        public string OperationName { get; set; }
    }
}
