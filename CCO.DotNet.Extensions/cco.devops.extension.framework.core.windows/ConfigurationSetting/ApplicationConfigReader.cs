using cco.devops.extension.framework.core.windows.Contracts;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace cco.devops.extension.framework.core.windows.ConfigurationSetting
{
    public class ApplicationConfigReader: IConfigurationReadable
    {

        private Configuration GetApplicationConfig()
        {
            var appConfig = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            return object.ReferenceEquals(appConfig, default(Configuration)) ? default(Configuration) : appConfig;
        }

        public List<string> GetAllConfigurationSectionsNames()
        {
            var appConfig   = GetApplicationConfig();
            var allSections = default(List<string>);

            if (!appConfig.Equals(default(Configuration)))
            {
                if (GetAllConfigurationGroupsNames().Any())
                {
                    allSections = new List<string>();

                    foreach (var groupName in GetAllConfigurationGroupsNames().Where(x=> !string.IsNullOrEmpty(x)))
                    {
                        //ATR: Get SectionGroup by Name first.
                        var groupByName = GetAnyConfigurationGroupByName(groupName);
                        foreach (ConfigurationSection item in groupByName.Sections)
                        {
                            allSections.Add(item.SectionInformation.SectionName);
                        }

                    }

                }


                
            }

            return allSections;
        }

        public List<ConfigurationSection> GetAllConfigurationSectionsObjects()
        {
            throw new NotImplementedException();
        }

        public List<string> GetAllConfigurationGroupsNames()
        {
            var appConfig = GetApplicationConfig();
            var allGroups = default(List<string>);

            if (!appConfig.Equals(default(Configuration)))
            {
                allGroups = (from ConfigurationSectionGroup itm in appConfig.SectionGroups select itm.SectionGroupName).ToList();
            }

            return allGroups;
        }

        public List<ConfigurationSectionGroup> GetAllConfigurationGroupsObjects()
        {
            var allGroupsObjects = default(List<ConfigurationSectionGroup>);
            var appConfig        = GetApplicationConfig();
            var allGroupsNames   = GetAllConfigurationGroupsNames();

            if (allGroupsNames.Any())
            {
                allGroupsObjects = allGroupsNames.
                    Select(groupName => appConfig.GetSectionGroup(groupName)).ToList();
            }   

            return allGroupsObjects;
        }

        public ConfigurationSectionGroup GetAnyConfigurationGroupByName(string name)
        {
            var sectionGroup = default(ConfigurationSectionGroup);

            if (!string.IsNullOrEmpty(name))
            {
                sectionGroup = GetApplicationConfig().GetSectionGroup(name);
                    
            }

            return sectionGroup;
        }

        public ConfigurationSection GetAnySectionByName(string name)
        {
            var sectionGroup = default(ConfigurationSection);

            if (!string.IsNullOrEmpty(name))
            {
                var allSections= GetAllConfigurationSectionsNames();

                if (allSections.Any())
                {
                    
                }


            }

            return sectionGroup;
        }
    }
}
