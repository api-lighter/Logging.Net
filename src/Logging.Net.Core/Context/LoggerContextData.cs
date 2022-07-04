using System;
using System.Runtime.CompilerServices;

namespace Logging.Net.Core.Context
{
    public class LoggerContextData
    {
        const int TragetStackFrameIndex = 8;

        public virtual Guid? RequestId { get; set; }
        public virtual string User { get; set; }
        public virtual string OperationId { get; set; }
        public virtual string OperationOwner { get; set; }
        public virtual string OperationName { get; set; }

        public virtual void BeginContext([CallerMemberName] string caller = "")
        {
            OperationName = caller;
        }
    }
}
