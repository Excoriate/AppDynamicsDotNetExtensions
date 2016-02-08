using cco.devops.extension.framework.core.windows.ConfigurationSetting.Runtime.ConfigurationLoader;
using cco.devops.extension.framework.core.windows.ConfigurationSetting.Runtime.Execution;
using cco.devops.extension.framework.core.windows.Contracts.ConfigurationSetting;
using cco.devops.extension.framework.core.windows.Contracts.ExecutionEnvironment;
using cco.devops.extension.pattern.ioc.Containers;
using cco.devops.extension.transversal.dto.Configuration;

namespace cco.devops.extension.clients.appdyn.actionhelper.Configuration
{
    public class ConfigurationManager
    {
        /// <summary>
        /// Load initial configuration and all info from Application Settings
        /// </summary>
        /// <returns></returns>
        public ConfigurationDto LoadInitialConfiguration()
        {
            var objContainer = new AppSettingReaderContainer();

            IConfigurationLoadeable objConfigHelper = objContainer.GetAnyInstance
                <IConfigurationLoadeable>();

            IOperativeSystemInformationLoadeable objOperativeSystem = objContainer.
                GetAnyInstance<IOperativeSystemInformationLoadeable>();
            

            return new ConfigurationDto()
            {
                ScripRunnerSettings = objConfigHelper.LoadScriptRunnerConfiguration(),
                IISRecyclerConfiguration = objConfigHelper.LoadIISRecyclerConfiguration(),
                IISRestarterConfiguration = objConfigHelper.LoadIISRestarterCondfiguration(),
                EventLogManager = objConfigHelper.LoadEventLogManagerConfiguration(),
                ExecutionInformation = objOperativeSystem.LoadExecutionEnvironmentInformation()

            };
        }


    }
}
