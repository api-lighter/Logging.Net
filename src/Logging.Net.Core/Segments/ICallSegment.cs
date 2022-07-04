using System;

namespace Logging.Net.Core.Segments
{
    /// <summary>
    /// Call segments interface.
    /// Used for accumulating call stack.
    /// Every segments has same context;
    /// </summary>
    public interface ICallSegment : IDisposable
    {
        void SetContextData(string key, string value);
        string GetContextData(string key);
    }
}
