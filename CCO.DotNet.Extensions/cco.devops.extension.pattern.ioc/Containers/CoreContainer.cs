using cco.devops.extension.clients.appdyn.actionhelper.Execution;
using cco.devops.extension.framework.core.Contracts;
using cco.devops.extension.pattern.ioc.Injector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cco.devops.extension.pattern.ioc.Containers
{
    public class CoreContainer : InjectorContainer
    {
        public override void Load()
        {
            Bind<IExecutionable>().To<ExecutionLogic>();
        }
    }
}
