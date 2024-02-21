using Movies.Observer;

namespace Movies.NotificationTypes
{
    public class WhatsAppNotification : INotificationObserver
    {
        public void Update(string message) => Console.WriteLine("WHATSAPP: " + message);
    }
}
