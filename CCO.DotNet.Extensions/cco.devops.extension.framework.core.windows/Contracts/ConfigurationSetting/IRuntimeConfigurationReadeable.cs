using System.Collections.Generic;
using cco.devops.extension.transversal.dto.Enums.Features;

namespace cco.devops.extension.framework.core.windows.Contracts.ConfigurationSetting
{
    public interface IRuntimeConfigurationReadeable
    {
        Dictionary<string, string> GetAllKeyValuesSettings();
        Dictionary<string, bool> GetFunctionalityByFeature(EnumFeatures.Features feature);
        Dictionary<string, string> GetValuesParametersByFeature(EnumFeatures.Features feature);
        Dictionary<string, bool> PrepareDictionariesWithFlags(Dictionary<string, string> dictionaryForParsing);
        Dictionary<string, string> PrepareDictionariesWithStrings(Dictionary<string, string> dictionaryForParsing);

        Dictionary<string, bool> GetAllFeaturesOnly();





    }
}

