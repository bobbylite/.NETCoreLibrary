namespace bobbylite.Notifications
{
    public interface IHandleNotifications<in T> where T : INotification
    {
        void Handle(T message);
    }
}