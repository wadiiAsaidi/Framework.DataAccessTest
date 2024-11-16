using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Core.IoC
{

    public interface IServiceLocator
    {
        T Resolve<T>();
        void Register<T>(Func<T> resolver);
        void Reset();
    }
    public class ServiceLocator : IServiceLocator
    {
        public Dictionary<Type, Func<object>> services;

        public void Register<T>(Func<T> resolver)
        {
            this.services[typeof(T)] = () => resolver();
        }

        public T Resolve<T>()
        {
            return (T)this.services[typeof(T)]();
        }

        public void Reset()
        {
            this.services.Clear();
        }
    }
}
