using System;
using System.Collections.Generic;  
using System.Configuration;
using System.Linq;
using System.Xml;
using cco.devops.extension.framework.core.windows.ConfigurationSetting.ConfigurationHelpers; 
using cco.devops.extension.framework.core.windows.Contracts.ConfigurationSetting;
using cco.devops.extension.transversal.dto.Enums.Features;
using NLog.Config;

namespace cco.devops.extension.framework.core.windows.ConfigurationSetting.ApplicationSettings
{
    public class RuntimeConfigurationReader: IRuntimeConfigurationReadeable
    {
        public Dictionary<string, string> GetAllKeyValuesSettings()
        {
            return ConfigurationManager.AppSettings.AllKeys
        .ToDictionary(k => k, v => ConfigurationManager.AppSettings[v]);

        }

        /// <summary>
        /// Get an filetered key value pair collection by string parameter
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        private Dictionary<string, string> FilterDictionaryKeyValueByParameterStarWith(string parameter)
        {
            var filteredDictionary = default(Dictionary<string, string>);

            if (!string.IsNullOrEmpty(parameter))
            {
                var mainCollection = GetAllKeyValuesSettings();

                if (mainCollection.Any())
                {
                    filteredDictionary = mainCollection.Where(x => x.Key.StartsWith(parameter))
                            .ToDictionary(y => y.Key, v => v.Value);

                }
            }

            return filteredDictionary;
        }



        /// <summary>
        /// ATR: Get functionality in Application Config by feature
        /// </summary>
        /// <param name="feature"></param>
        /// <returns></returns>
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

                        auxfunctionsByFeature = FilterDictionaryKeyValueByParameterStarWith("ScriptRunnerFunctionality");
                        break;
                }

                if (!object.ReferenceEquals(auxfunctionsByFeature, null) && 
                    auxfunctionsByFeature.Any())
                {
                    functionsByFeature = PrepareDictionariesWithFlags(auxfunctionsByFeature);
                }
                  
            }

            return functionsByFeature;
        }

        /// <summary>
        /// Get a key value pair collection with the specific functionality values and parameters for specific feature
        /// </summary>
        /// <param name="feature"></param>
        /// <returns></returns>
        public Dictionary<string, string> GetValuesParametersByFeature(EnumFeatures.Features feature)
        {
            var allSettings           = GetAllKeyValuesSettings();    
            var auxfunctionsByFeature = default(Dictionary<string, string>);

            if (allSettings.Any())
            {
                switch (feature)
                {
                    case EnumFeatures.Features.ScriptRunner:

                        auxfunctionsByFeature = FilterDictionaryKeyValueByParameterStarWith("ScriptRunnerValuesParameters");
                       
                        break;
                }

                if (!object.ReferenceEquals(auxfunctionsByFeature, null) &&
                    auxfunctionsByFeature.Any())
                {
                    auxfunctionsByFeature = PrepareDictionariesWithStrings(auxfunctionsByFeature);
                }

            }

            return auxfunctionsByFeature;
        }

        /// <summary>
        /// Return a prepare dictionary (key value pair) with a string key and a flag value
        /// </summary>
        /// <param name="dictionaryForParsing"></param>
        /// <returns></returns>
        public Dictionary<string, bool> PrepareDictionariesWithFlags(Dictionary<string, string> dictionaryForParsing)
        {
            var objToParse = default(Dictionary<string, bool>);

            if (!object.ReferenceEquals(dictionaryForParsing, null))
            {
                if (dictionaryForParsing.Any())
                {
                    var objParsingHelper = new AppConfigHelpers();

                    objToParse = dictionaryForParsing.ToDictionary
                        (item => objParsingHelper.GetSplitStringFromConfigByParameter(item.Key, '_', false), 
                        item => Boolean.Parse(item.Value)); 
                }

            }

            return objToParse;
        }

        /// <summary>
        /// Prepare and get a dictionary with both string key/values, formatted
        /// </summary>
        /// <param name="dictionaryForParsing"></param>
        /// <returns></returns>
        public Dictionary<string, string> PrepareDictionariesWithStrings(Dictionary<string, string> dictionaryForParsing)
        {
            var objToParse = default(Dictionary<string, string>);

            if (!object.ReferenceEquals(dictionaryForParsing, null))
            {
                if (dictionaryForParsing.Any())
                {
                    var objParsingHelper = new AppConfigHelpers();

                    objToParse = dictionaryForParsing.ToDictionary
                        (item => objParsingHelper.GetSplitStringFromConfigByParameter(item.Key, '_', false),
                        item => (item.Value));
                }

            }

            return objToParse;
        }

        /// <summary>
        /// Return an key value pair collection with al features
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, bool> GetAllFeaturesOnly()
        {
            return PrepareDictionariesWithFlags(FilterDictionaryKeyValueByParameterStarWith("Feature"));
        }

        /// <summary>
        /// Get a filtered key valuen pair collection with an specific key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public Dictionary<string, bool> GetAnyKeyValueSettingByKey(string key)
        {
            var finalCollection      = default(Dictionary<string, bool>);

            if (!string.IsNullOrEmpty(key))
            {
                var auxFileteredFeatures = GetAllFeaturesOnly().Where(x =>
               string.Equals(x.Key, key, StringComparison.CurrentCultureIgnoreCase));

                if (!object.ReferenceEquals(auxFileteredFeatures, null) &&
                    auxFileteredFeatures.Any())
                {
                    finalCollection = (auxFileteredFeatures) as Dictionary<string, bool>;

                }
            }

            return finalCollection;

        }

        /// <summary>
        /// Check if any setting is enabled or Not. 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool CheckIfAnyKeyValueSettingIsEnabledByKey(string key)
        {
            var isEnabled = default(bool);

            if (!string.IsNullOrEmpty(key))
            {
                foreach(var item in (GetAnyKeyValueSettingByKey(key)))
                {
                    isEnabled = item.Value;
                } 
            }

            return isEnabled;
        }

    }
}
