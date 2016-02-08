using cco.devops.extension.pattern.ioc.Injector;
using cco.devops.extension.transversal.logger.Contracts;
using cco.devops.extension.transversal.logger.NLogConfiguration;

namespace cco.devops.extension.pattern.ioc.Containers
{
    public class LogManagerContainer: InjectorContainer
    {
        public override void Load()
        {
            Bind(typeof(ILoggerConfigurable<>)).To(typeof(NlogConfigManager<>));


        }

    }
}
