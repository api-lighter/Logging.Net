using Logging.Net.Core.Segments;
using System;
using System.Collections.Concurrent;
using System.Collections.Immutable;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;

namespace Logging.Net.Core.Context
{
    public static class LoggerContext
    {
        const string SegmentSeparator = @"\";

        private static readonly AsyncLocal<ImmutableStack<SingleSegment>> CallsSegmentsStack =
            new AsyncLocal<ImmutableStack<SingleSegment>>();

        public static string FullPath => string.Join(SegmentSeparator, CallsSegmentsStack.Value.Reverse().Select(x => x.Name));
        public static string CurrentSegmentName => CallsSegmentsStack.Value.Peek().Name;

        /// <summary>
        /// Just for access to and safety set <see cref="CallsSegmentsStack"/>
        /// </summary>
        public static ImmutableStack<SingleSegment> CallsSegments
        {
            get
            {
                if (CallsSegmentsStack.Value is null)
                    InitSegmentsStack();
                return CallsSegmentsStack.Value;
            }
            set => CallsSegmentsStack.Value = value;
        }

        public static void InitSegmentsStack()
        {
            CallsSegmentsStack.Value = ImmutableStack.Create<SingleSegment>().Push(SingleSegment.Empty);
        }

        public static ICallSegment NewSegment(string name, Action onCreate = null, Action onDispose = null)
        {
            return new SegmentDisposer(name, CallsSegments.Peek(), onCreate, onDispose);
        }

        public static ICallSegment NewSegment([CallerFilePath] string callerFilePath = null,
            [CallerMemberName] string callerMemberName = null)
        {
            return NewSegment(name: $"{Path.GetFileNameWithoutExtension(callerFilePath)}.{callerMemberName}");
        }

        public static void SetContextData(string key, string value) => CallsSegments.Last().SetContextData(key, value);
        public static string GetContextData(string key) => CallsSegments.Peek().GetContextData(key);
        public static object GetContextObjectData(string key) => CallsSegments.Peek().GetObjectValue(key);
        public static ConcurrentDictionary<string, object> CurrentSegmentContext => CallsSegments.Peek().ContextRawData;
        public static int LogNumber => CallsSegments.Peek().LogRecordNumber;
        public static int SegmentNumber => CallsSegments.Peek().SegmentNumber;

        public static int NextLogNumber() => CallsSegments.Peek().NextLogNumber();
    }
}
