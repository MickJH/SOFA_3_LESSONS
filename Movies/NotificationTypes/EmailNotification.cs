using Movies.Observer;

namespace Movies.NotificationTypes
{
    public class EmailNotification : INotificationObserver
    {
        public void Update(string message) => Console.WriteLine("EMAIL: " + message);
    }
}
