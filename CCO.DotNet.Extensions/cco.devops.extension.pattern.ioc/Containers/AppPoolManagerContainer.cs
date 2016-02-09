using cco.devops.extension.framework.core.iis.Contracts;
using cco.devops.extension.framework.core.iis.IISOperations;
using cco.devops.extension.pattern.ioc.Injector;

namespace cco.devops.extension.pattern.ioc.Containers
{
    public class AppPoolManagerContainer : InjectorContainer
    {
        public override void Load()
        {
            Bind<IISToolsReadeable>().To<IISReaderManager>();
        }
    }
}
