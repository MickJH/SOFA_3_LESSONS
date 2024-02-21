using Movies.Observer;

namespace Movies.NotificationTypes
{
    public class ConsoleNotification : INotificationObserver
    {
        public void Update(string message) => Console.WriteLine("CONSOLE: " + message);
    }
}
