using System;
using System.Runtime.CompilerServices;

namespace Logging.Net.Core.Context
{
    public class LoggerContext
    {
        const int TragetStackFrameIndex = 8;

        public Guid? RequestId { get; set; }
        public string User { get; set; }
        public string OperationId { get; set; }
        public string OperationOwner { get; set; }
        public string OperationName { get; set; }

        public void BeginContext([CallerMemberName] string caller = "")
        {
            OperationName = caller;
        }
    }
}
