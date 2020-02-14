using Autofac;
using bobbylite.Notifications;

namespace bobbylite.DependencyInjection.Modules
{
    public class CoreModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c => new ObjectResolver(c.Resolve<IComponentContext>())).AsSelf().SingleInstance();
            builder.RegisterType<NotificationManager>().AsSelf().SingleInstance();
        }
    }
}