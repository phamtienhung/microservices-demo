using System.Threading.Tasks;

namespace MD.SharedKernel.Interfaces
{
    public interface IHandle<T> where T : IEvent
    {
        Task Handle(T args);
    }
}