using System;

namespace MD.SharedKernel.Interfaces
{
    public interface IEvent
    {
        Guid Guid { get; }
        DateTime DateTimeEventOccured { get; }
        Guid TransactionId { get; }
        int VersionId { get; }
    }
}