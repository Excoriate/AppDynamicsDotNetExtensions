using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using cco.devops.extension.framework.core.windows.ConfigurationSetting;
using cco.devops.extension.framework.core.windows.Contracts;
using cco.devops.extension.transversal.logger.Contracts;
using cco.devops.extension.transversal.logger.NLogConfiguration;

namespace cco.devops.extension.pattern.ioc.Containers
{
    public class ToolsContainer: Injector.InjectorContainer
    {
        public override void Load()
        {
            Bind(typeof(ILoggerConfigurable<>)).To(typeof(NlogConfigManager<>));
            //Bind(IConfigurationReadable).To(ApplicationConfigReader);




        }
    }
}
