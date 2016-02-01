using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Xml;
using cco.devops.extension.framework.core.windows.ConfigurationSetting.Runtime.XmlReader;
using cco.devops.extension.framework.core.windows.Contracts.ConfigurationSetting;
using cco.devops.extension.transversal.dto.Enums.Features;

namespace cco.devops.extension.framework.core.windows.ConfigurationSetting.ApplicationSettings
{
    public class RuntimeConfigurationReader: IRuntimeConfigurationReadeable
    {
        public Dictionary<string, string> GetAllKeyValuesSettings()
        {
            return ConfigurationManager.AppSettings.AllKeys
        .ToDictionary(k => k, v => ConfigurationManager.AppSettings[v]);

        }

        public Dictionary<string, bool> GetFunctionalityByFeature(EnumFeatures.Features feature)
        {
            var allSettings           = GetAllKeyValuesSettings();
            var functionsByFeature    = default(Dictionary<string, bool>);
            var auxfunctionsByFeature = default(Dictionary<string, string>);

            if (allSettings.Any())
            {
                switch (feature)
                {
                        case EnumFeatures.Features.ScriptRunner:

                        auxfunctionsByFeature =
                            allSettings.Where(x => x.Key.StartsWith("[ScriptRunnerFunctionality]"))
                            .ToDictionary(y=> y.Key, v => v.Value);
                        break;
                }

                if (!object.ReferenceEquals(auxfunctionsByFeature, null) && 
                    auxfunctionsByFeature.Any())
                {
                    functionsByFeature = auxfunctionsByFeature.ToDictionary
                        (item => item.Key, item => Boolean.Parse(item.Value));
                }
                  
            }

            return functionsByFeature;
        }

        public Dictionary<string, string> GetValuesParametersByFunctionality(EnumFeatures.Functionality functionality)
        {
            throw new NotImplementedException();
        }

        private Dictionary<string, bool> PrepareDictionariesWithFlasg(Dictionary<string, string> dictionaryForParsing)
        {
            var objToParse = default(Dictionary<string, bool>);

            if (!object.ReferenceEquals(dictionaryForParsing, null))
            {
                if (dictionaryForParsing.Any())
                {
                    objToParse = dictionaryForParsing.ToDictionary
                        (item => item.Key, item => Boolean.Parse(item.Value));

                    if (objToParse.Any())
                    {
                        //TODO: remove prefix.
                        
                    }
                }

            }

            return objToParse;
        }
    }
}
