using System;
using bobbylite.Notifications;
using Autofac;

namespace bobbylite {
    public class ApplicationStartupService : IAutoStart {
        public NotificationManager NotificationManager {get; set;}

        public void Start() => NotificationManager.Notify(new ApplicationStartedNotification());
    }
}