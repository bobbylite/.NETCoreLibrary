using System;
using System.Threading.Tasks;
using Xunit;
using bobbylite;
using bobbylite.DependencyInjection;
using Autofac;

namespace bobbylite
{
    public class UnitTest1
    {
        private IContainer _container;

        [Fact]
        public void Test1()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule(new bobbylite.DependencyInjection.Modules.CoreModule());
            builder.RegisterModule(new ApplicationModule());
            _container = builder.Build();

            AutoStart();
        }

        private void AutoStart() {
            var resolved = _container.Resolve<ObjectResolver>();
            foreach(var instance in resolved.GetAll<IAutoStart>()) {
                Task.Run(() => {
                    try {
                        instance.Start();
                    } catch (Exception) {
                        // Handle Exception
                    }
                });
            }
        }
    }
}
