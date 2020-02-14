using System;
using bobbylite.Handlers;

namespace bobbylite {
    public class ApplicationStartedNotificationHandler : ApplicationHandler<ApplicationStartedNotification> {
        protected override void HandleNotification(ApplicationStartedNotification message) {
            Console.WriteLine("Application Started Successfully...");
        }
    }
}