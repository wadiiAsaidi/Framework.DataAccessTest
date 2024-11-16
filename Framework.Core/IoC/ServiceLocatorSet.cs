using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace Framework.Core.IoC
{
    interface IServiceLocatorSet
    {
        void Configure();
    }
    public abstract class ServiceLocatorSet : ServiceLocator, IServiceLocatorSet
    {
        System.Threading.AsyncLocal<IServiceLocatorSet> _services = new System.Threading.AsyncLocal<IServiceLocatorSet>();
        public ServiceLocatorSet()
        {
            this.services = new Dictionary<Type, Func<object>>();
            Configure();

        }
        public void Configure()
        {
            this.OnConfigure();
        }
        public abstract void OnConfigure();
    }
}
