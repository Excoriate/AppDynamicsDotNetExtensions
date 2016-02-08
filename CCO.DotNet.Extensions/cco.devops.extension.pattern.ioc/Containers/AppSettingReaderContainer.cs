
using cco.devops.extension.framework.core.windows.ConfigurationSetting.ApplicationSettings;
using cco.devops.extension.framework.core.windows.ConfigurationSetting.Runtime.ConfigurationLoader;
using cco.devops.extension.framework.core.windows.ConfigurationSetting.Runtime.Execution;
using cco.devops.extension.framework.core.windows.Contracts.ConfigurationSetting;
using cco.devops.extension.framework.core.windows.Contracts.ExecutionEnvironment;
using cco.devops.extension.pattern.ioc.Injector;

namespace cco.devops.extension.pattern.ioc.Containers
{
    public class AppSettingReaderContainer:InjectorContainer
    {
        public override void Load()
        {
            Bind<IRuntimeConfigurationReadeable>().To<RuntimeConfigurationReader>();
            Bind<IOperativeSystemInformationLoadeable>().To<ExecutionInformationReader>();
            Bind<IConfigurationLoadeable>().To<RuntimeConfigurationLoader>();
            Bind<IConfigurationReadable>().To<CustomSectionsApplicationReader>();


        }



    }
}
