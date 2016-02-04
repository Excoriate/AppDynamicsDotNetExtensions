
using System.Linq;
using cco.devops.extension.framework.core.windows.Contracts.ConfigurationSetting;
using cco.devops.extension.pattern.ioc.Containers;
using cco.devops.extension.transversal.dto.Configuration;
using cco.devops.extension.transversal.dto.Enums.Features;

namespace cco.devops.extension.framework.core.Module.ApplicationSetting
{
    public class ApplicationSettingReader
    {
        /// <summary>
        /// Load in DTO object all the parameters and configuration enabled for SCRIPTRUNNER Feature. 
        /// </summary>
        /// <returns></returns>
        public ScriptRunnerConfigurationDto GetScriptRunnerConfiguration()
        {
            ScriptRunnerConfigurationDto objConfigurationLoaded = default(ScriptRunnerConfigurationDto);
            var injectedInstance = new AppSettingReaderContainer().GetAnyInstance<IRuntimeConfigurationReadeable>();

            if (!object.ReferenceEquals(injectedInstance, null))
            {
                objConfigurationLoaded  = new ScriptRunnerConfigurationDto()
                {
                    Functionality    = injectedInstance.GetFunctionalityByFeature(EnumFeatures.Features.ScriptRunner) ,
                    ValuesParameters = injectedInstance.GetValuesParametersByFeature(EnumFeatures.Features.ScriptRunner),
                    IsEnabled        = injectedInstance.CheckIfAnyKeyValueSettingIsEnabledByKey("ScriptRunner")
                };
                
            }

            return objConfigurationLoaded;

        }





    }
}
