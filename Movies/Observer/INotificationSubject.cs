using System;

namespace Movies.Observer
{
    public interface INotificationSubject
    {
        void RegisterObserver(INotificationObserver observer);
        void RemoveObserver(INotificationObserver observer);
        void NotifyObservers(string message);
    }
}
