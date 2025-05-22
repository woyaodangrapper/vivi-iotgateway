using System.Collections.Concurrent;
using System.Reactive.Subjects;

namespace Vivi.SharedKernel.Contracts.Queue;

public class QueueContext<T>
{
    public ConcurrentQueue<object> Queue { get; } = new();
    public SemaphoreSlim Signal { get; } = new(0);
    public ISubject<T>? Subject { get; set; } = new Subject<T>();
}