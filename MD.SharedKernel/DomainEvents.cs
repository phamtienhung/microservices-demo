using MD.SharedKernel.Interfaces;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MD.SharedKernel
{
    /// <summary>
    /// http://msdn.microsoft.com/en-gb/magazine/ee236415.aspx#id0400046
    /// </summary>
    public static class DomainEvents
    {
        [ThreadStatic]
        private static List<Delegate> actions;

        private static Container Container { get; set; }

        static DomainEvents()
        {
        }

        public static void SetContainer(Container container)
        {
            Container = container;
        }

        public static void Register<T>(Action<T> callback) where T : IEvent
        {
            if (actions == null)
            {
                actions = new List<Delegate>();
            }
            actions.Add(callback);
        }

        public static void ClearCallbacks()
        {
            actions = null;
        }

        public static async Task Raise<T>(T args) where T : IEvent
        {
            var listtask = new List<Task>();

            //var persistence = Container.GetInstance<IEventPersistenceHandle>();
            //listtask.Add(persistence.Handle(args));
            foreach (var handler in Container.GetAllInstances<IHandle<T>>())
            {
                listtask.Add(handler.Handle(args));
            }

            foreach (var task in listtask)
            {
                await task;
            }

            if (actions != null)
            {
                foreach (var action in actions)
                {
                    if (action is Action<T>)
                    {
                        ((Action<T>)action)(args);
                    }
                }
            }
        }
    }
}