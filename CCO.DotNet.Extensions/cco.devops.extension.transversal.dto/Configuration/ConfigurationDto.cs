using System;

namespace cco.devops.extension.transversal.dto.Configuration
{
    [Serializable]
    public sealed class ConfigurationDto
    {
        public ScriptRunnerConfigurationDto ScripRunnerSettings { get; set; }
        public IISRestarterConfigurationDto IISRestarterConfiguration { get; set; }
        public IISRecyclerConfigurationDto IISRecyclerConfiguration { get; set; }
        public EventLogManagerDto EventLogManager { get; set; }
        public EnvironmentConfigurationInformationDto ExecutionInformation { get; set; }



    }
}
