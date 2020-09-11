using System;
using System.Collections.Generic;

using CommonServiceLocator;

using Microsoft.Extensions.DependencyInjection;

namespace EasyConsole.BetterDemo.DependencyInjection
{
    public class MyServiceLocator : ServiceLocatorImplBase
    {
        private IServiceProvider services;

        public MyServiceLocator(IServiceProvider services)
        {
            this.services = services;
        }

        protected override IEnumerable<object> DoGetAllInstances(Type serviceType)
        {
            return this.services.GetServices(serviceType);
        }

        protected override object DoGetInstance(Type serviceType, string key)
        {
            return this.services.GetService(serviceType);
        }
    }
}
