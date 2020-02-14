using System;
using System.Collections.Generic;
using System.Linq;
using Autofac;

namespace bobbylite.DependencyInjection
{
    public class ObjectResolver
    {
        private readonly IComponentContext _componentContext;

        public ObjectResolver(IComponentContext componentContext)
        {
            _componentContext = componentContext;
        }

        public T Get<T>()
        {
            return _componentContext.Resolve<T>();
        }

        public T Get<T>(params Tuple<string, object>[] constructorArgs)
        {
            return _componentContext.Resolve<T>(constructorArgs.Select(arg => new NamedParameter(arg.Item1, arg.Item2)));
        }

        public IEnumerable<T> GetAll<T>()
        {
            return _componentContext.Resolve<IEnumerable<T>>();
        } 
    }
}
