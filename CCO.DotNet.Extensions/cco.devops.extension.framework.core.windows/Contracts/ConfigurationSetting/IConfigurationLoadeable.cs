using cco.devops.extension.transversal.dto.Configuration;   

namespace cco.devops.extension.framework.core.windows.Contracts.ConfigurationSetting
{
    public interface IConfigurationLoadeable
    {
        ScriptRunnerConfigurationDto LoadScriptRunnerConfiguration();
        EventLogManagerDto LoadEventLogManagerConfiguration();
        IISRecyclerConfigurationDto LoadIISRecyclerConfiguration();
        IISRestarterConfigurationDto LoadIISRestarterCondfiguration();
    }
}
