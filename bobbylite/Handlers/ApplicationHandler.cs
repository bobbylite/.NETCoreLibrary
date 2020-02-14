using System;
using bobbylite.Notifications;

namespace bobbylite.Handlers
{
    public abstract class ApplicationHandler<T> : IHandleNotifications<T> where T : INotification
    {
        public void Handle(T message)
        {
            try
            {
                HandleNotification(message);
            }
            catch (Exception exception)
            {
                //
            }
        }

        protected abstract void HandleNotification(T message);
    }
}