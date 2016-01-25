
using CCO.Pattern.IOC.Injector.Injector;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CCO.Pattern.IOC.Injector.Containers
{
    public class AppPoolManagerContainer : InjectorContainer
    {
        public override void Load()
        {
            //Bind(typeof(IConfigReadable<>)).To(typeof(AppConfigReader<>));
        }
    }
}
