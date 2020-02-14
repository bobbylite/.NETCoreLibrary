using bobbylite.DependencyInjection;

namespace bobbylite.Notifications
{
    public class NotificationManager
    {
        private readonly ObjectResolver _objectResolver;

        public NotificationManager(ObjectResolver objectResolver)
        {
            _objectResolver = objectResolver;
        }

        public void Notify<T>(T message) where T : INotification
        {
            HandleNotification(_objectResolver, message);
        }

        private static void HandleNotification<T>(ObjectResolver objectResolver, T message) where T : INotification
        {
            foreach (var handler in objectResolver.GetAll<IHandleNotifications<T>>())
            {
                handler.Handle(message);
            }
        }
    }
}
