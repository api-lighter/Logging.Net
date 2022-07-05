using System;
using System.Collections.Generic;

namespace Logging.Net.Core.Context
{
    public class LoggerContextFacade : LoggerContextData
    {
        public override Guid? RequestId
        {
            get => GetGuidSafety(LoggerContext.GetContextData("requestId"));
            set => base.RequestId = value;
        }
        public override string User
        {
            get => LoggerContext.GetContextData("user");
            set => LoggerContext.SetContextData("user", value);
        }
        public override string OperationId
        {
            get => LoggerContext.GetContextData("operationId");
            set => LoggerContext.SetContextData("operationId", value);
        }
        public override string OperationOwner
        {
            get => LoggerContext.GetContextData("owner");
            set => LoggerContext.SetContextData("owner", value);
        }
        public override string OperationName
        {
            get => LoggerContext.GetContextData("operationName");
            set => LoggerContext.SetContextData("operationName", value);
        }

        public string Operation => LoggerContext.CurrentSegmentName;
        public string OperationStack => LoggerContext.FullPath;

        public IDictionary<string, object> ScopeContext => LoggerContext.CurrentSegmentContext;

        private Guid GetGuidSafety(string value)
        {
            return Guid.TryParse(value, out var valueGuid) ? valueGuid : Guid.NewGuid();
        }
    }
}
