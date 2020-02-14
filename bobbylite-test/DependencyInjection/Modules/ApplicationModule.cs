using System.Reflection;
using Autofac;
using Module = Autofac.Module;
using bobbylite.Notifications;

namespace bobbylite {
    public class ApplicationModule : Module {
        protected override void Load(ContainerBuilder builder) {
            StartUp(builder);
            StartNotificationManager(builder);
        }

        private void StartUp(ContainerBuilder builder) {
            builder.Register(c => new ApplicationStartupService())
                .As<IAutoStart>()
                .SingleInstance()
                .PropertiesAutowired(PropertyWiringOptions.AllowCircularDependencies);
        }

        private void StartNotificationManager(ContainerBuilder builder) {
            builder.RegisterType<ApplicationStartedNotificationHandler>()
                .As<IHandleNotifications<ApplicationStartedNotification>>()
                .PropertiesAutowired()
                .SingleInstance();
        }
    }
}