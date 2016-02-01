using System.Collections.Generic;
using cco.devops.extension.transversal.dto.Enums.Features;

namespace cco.devops.extension.framework.core.windows.Contracts.ConfigurationSetting
{
    public interface IRuntimeConfigurationReadeable
    {
        Dictionary<string, string> GetAllKeyValuesSettings();
        Dictionary<string, bool> GetFunctionalityByFeature(EnumFeatures.Features feature);
        Dictionary<string, string> GetValuesParametersByFunctionality(EnumFeatures.Functionality functionality);
        



    }
}
