using System.Collections.Generic;
using System.Configuration;

namespace cco.devops.extension.framework.core.windows.Contracts.ConfigurationSetting
{
    public interface IConfigurationReadable
    {
        List<string> GetAllConfigurationSectionsNames();
        List<ConfigurationSection> GetAllConfigurationSectionsObjects();
        List<string> GetAllConfigurationGroupsNames();
        List<ConfigurationSectionGroup> GetAllConfigurationGroupsObjects();
        ConfigurationSectionGroup GetAnyConfigurationGroupByName(string name);
        ConfigurationSection GetAnySectionByName(string name);

    }
}
