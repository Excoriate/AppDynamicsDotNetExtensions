using System;
using cco.devops.extension.framework.core.windows.Contracts.ConfigurationSetting;
using cco.devops.extension.transversal.dto.Configuration;
using cco.devops.extension.framework.core.windows.ConfigurationSetting.ApplicationSettings;

namespace cco.devops.extension.framework.core.windows.ConfigurationSetting.Runtime.ConfigurationLoader
{
    /// <summary>
    /// Class that load all configuration from AppConfig file.  It's necesarry for run
    /// custom features in extension. 
    /// </summary>
    public class RuntimeConfigurationLoader : IConfigurationLoadeable
    {
        public EventLogManagerDto LoadEventLogManagerConfiguration()
        {
            IRuntimeConfigurationReadeable configLoader = default(IRuntimeConfigurationReadeable);
            var scriptConfiguration = default(EventLogManagerDto);

            configLoader = new RuntimeConfigurationReader();

            scriptConfiguration = new EventLogManagerDto()
            {
                Functionality = configLoader.GetFunctionalityByFeature(transversal.dto.Enums.Features.EnumFeatures.Features.EventLogManager),
                ValuesParameters = configLoader.GetValuesParametersByFeature(transversal.dto.Enums.Features.EnumFeatures.Features.EventLogManager)

            };

            return scriptConfiguration;
        }

        public IISRecyclerConfigurationDto LoadIISRecyclerConfiguration()
        {
            IRuntimeConfigurationReadeable configLoader = default(IRuntimeConfigurationReadeable);
            var scriptConfiguration = default(IISRecyclerConfigurationDto);

            configLoader = new RuntimeConfigurationReader();

            scriptConfiguration = new IISRecyclerConfigurationDto()
            {
                Functionality = configLoader.GetFunctionalityByFeature(transversal.dto.Enums.Features.EnumFeatures.Features.IISRecycler),
                ValuesParameters = configLoader.GetValuesParametersByFeature(transversal.dto.Enums.Features.EnumFeatures.Features.IISRecycler)

            };

            return scriptConfiguration;

        }

        public IISRestarterConfigurationDto LoadIISRestarterCondfiguration()
        {
            IRuntimeConfigurationReadeable configLoader = default(IRuntimeConfigurationReadeable);
            var scriptConfiguration = default(IISRestarterConfigurationDto);

            configLoader = new RuntimeConfigurationReader();

            scriptConfiguration = new IISRestarterConfigurationDto()
            {
                Functionality = configLoader.GetFunctionalityByFeature(transversal.dto.Enums.Features.EnumFeatures.Features.IISRestarter),
                ValuesParameters = configLoader.GetValuesParametersByFeature(transversal.dto.Enums.Features.EnumFeatures.Features.IISRestarter)

            };

            return scriptConfiguration;
        }

        /// <summary>
        /// Load all configuration from ScripRunner  configuration. 
        /// </summary>
        /// <returns></returns>
        public ScriptRunnerConfigurationDto LoadScriptRunnerConfiguration()
        {
            IRuntimeConfigurationReadeable configLoader = default(IRuntimeConfigurationReadeable);
            var scriptConfiguration = default(ScriptRunnerConfigurationDto);  

            configLoader = new RuntimeConfigurationReader();

            scriptConfiguration = new ScriptRunnerConfigurationDto()
            {
                Functionality = configLoader.GetFunctionalityByFeature(transversal.dto.Enums.Features.EnumFeatures.Features.ScriptRunner),
                ValuesParameters = configLoader.GetValuesParametersByFeature(transversal.dto.Enums.Features.EnumFeatures.Features.ScriptRunner)
                
            };

            return scriptConfiguration;

        }
    }
}
