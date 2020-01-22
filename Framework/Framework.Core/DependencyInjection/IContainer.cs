using System;
using System.Collections.Generic;

namespace Framework.Core.DependencyInjection
{
    public interface IContainer
    {
        T Resolve<T>();

        T Resolve<T>(Func<T, bool> predicate);

        T Resolve<T>(string objectName);

        T TryResolve<T>();

        IEnumerable<T> ResolveAll<T>();
    }
}
