using Framework.Core.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sales.SalesManagement.WebApi
{
    public class Container : IContainer
    {
        IServiceProvider serviceProvider;

        public Container(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public T Resolve<T>()
        {
            return serviceProvider.GetService<T>();
        }

        public T Resolve<T>(Func<T, bool> predicate)
        {
            return serviceProvider.GetServices<T>().First(predicate);
        }

        public T Resolve<T>(string objectName)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> ResolveAll<T>()
        {
            throw new NotImplementedException();
        }

        public T TryResolve<T>()
        {
            throw new NotImplementedException();
        }
    }
}