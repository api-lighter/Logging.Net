using System;
using System.Collections.Concurrent;
using System.Threading;

namespace Logging.Net.Core.Segments
{
    public class SingleSegment
    {
        private int _logRecordNumber;

        public int SegmentNumber { get; set; }
        public int LogRecordNumber => _logRecordNumber;

        private readonly SingleSegment _parent;
        private readonly ConcurrentDictionary<string, object> _localRawData;
        private readonly ConcurrentDictionary<string, object> _contextRawData;

        private SingleSegment()
        {
            Name = string.Empty;
            _localRawData = new ConcurrentDictionary<string, object>();
            _contextRawData = new ConcurrentDictionary<string, object>();
        }

        public SingleSegment(string name, SingleSegment parent)
        {
            Name = name;
            SegmentNumber = parent.SegmentNumber + 1;

            _parent = parent;

            _localRawData = new ConcurrentDictionary<string, object>();
            _contextRawData = new ConcurrentDictionary<string, object>(_parent._contextRawData);
        }

        public string Name { get; }
        public ConcurrentDictionary<string, object> LocalRawData => _localRawData;
        public ConcurrentDictionary<string, object> ContextRawData => MergeContextWithParentData();


        private ConcurrentDictionary<string, object> MergeContextWithParentData()
        {
            throw new NotImplementedException();
        }

        public string GetContextData(string key) => ContextRawData.TryGetValue(key, out var value) ? value?.ToString() : null;
        public object GetObjectValue(string key) => ContextRawData.TryGetValue(key, out var value) ? value :
            _contextRawData.TryGetValue(key, out var contextValue) ? contextValue : null;
        public void SetContextData(string key, string value) => _localRawData[key] = value;

        public static SingleSegment Empty => new SingleSegment();

        public int NextLogNumber() => Interlocked.Increment(ref _logRecordNumber);
    }
}
