
using cco.devops.extension.framework.core.windows.ConfigurationSetting.ApplicationSettings;
using cco.devops.extension.framework.core.windows.Contracts.ConfigurationSetting;
using cco.devops.extension.pattern.ioc.Injector;

namespace cco.devops.extension.pattern.ioc.Containers
{
    public class AppSettingReaderContainer:InjectorContainer
    {
        public override void Load()
        {
            Bind<IRuntimeConfigurationReadeable>().To<RuntimeConfigurationReader>();

        }



    }
}
