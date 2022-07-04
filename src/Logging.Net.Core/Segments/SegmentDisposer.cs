using System;

namespace Logging.Net.Core.Segments
{
    internal class SegmentDisposer : ICallSegment
    {
        private bool _disposed;

        private readonly Action _onDisposed;
        private readonly Action _onDispose;
        private readonly SingleSegment _singleSegment;

        public string Name => _singleSegment.Name;

        public SegmentDisposer(string name, SingleSegment _disposableSegment, Action dispose,
            Action onCreateSegment, Action onDisposed = null)
        {
            _onDisposed = onDisposed;
            _onDispose = dispose;
            _singleSegment = _disposableSegment;
            onCreateSegment?.Invoke();
        }

        public void Dispose()
        {
            if (_disposed)
                return;
            _onDispose.Invoke();
            _disposed = true;
            _onDisposed?.Invoke();
        }

        public string GetContextData(string key)
        {
            if (_disposed)
                return null;
            return _singleSegment.GetContextData(key);
        }

        public void SetContextData(string key, string value)
        {
            if (_disposed)
                return;
            _singleSegment.SetContextData(key, value);
        }
    }
}
