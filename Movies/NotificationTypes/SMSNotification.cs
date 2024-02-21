using Movies.Observer;

namespace Movies.NotificationTypes
{
    public class SMSNotification : INotificationObserver
    {
        public void Update(string message) => Console.WriteLine("SMS: " + message);
    }
}
