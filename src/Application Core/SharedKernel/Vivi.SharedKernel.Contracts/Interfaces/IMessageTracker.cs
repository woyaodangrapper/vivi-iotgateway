using Vivi.SharedKernel.Application.Contracts.Enums;

namespace Vivi.SharedKernel.Application.Contracts.Interfaces;

public interface IMessageTracker
{
    TrackerKind Kind { get; }
    Task<bool> HasProcessedAsync(long eventId, string trackerName);
    Task MarkAsProcessedAsync(long eventId, string trackerName);
}