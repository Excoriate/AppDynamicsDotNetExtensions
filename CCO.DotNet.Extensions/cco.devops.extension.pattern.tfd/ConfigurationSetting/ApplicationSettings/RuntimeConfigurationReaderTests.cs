using System.Linq;
using cco.devops.extension.framework.core.windows.ConfigurationSetting.ApplicationSettings;
using cco.devops.extension.framework.core.windows.Contracts.ConfigurationSetting;
using cco.devops.extension.transversal.dto.Enums.Features;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace cco.devops.extension.framework.core.windows.ConfigurationSetting.ApplicationSettings.Tests
{
    [TestClass()]
    public class RuntimeConfigurationReaderTests
    {
        [TestMethod()]
        public void GetAllKeyValuesSettingsTest()
        {
            IRuntimeConfigurationReadeable instance = new RuntimeConfigurationReader();

            Assert.IsTrue(instance.GetAllKeyValuesSettings().Any());
            Assert.IsNotNull(instance.GetAllKeyValuesSettings());


        }

        [TestMethod()]
        public void GetFunctionalityByFeatureTest()
        {
            IRuntimeConfigurationReadeable instance = new RuntimeConfigurationReader();

            Assert.IsNotNull(instance.GetFunctionalityByFeature(EnumFeatures.Features.ScriptRunner));
            Assert.IsTrue(instance.GetFunctionalityByFeature(EnumFeatures.Features.ScriptRunner).Any());
            Assert.IsNotNull(instance.GetFunctionalityByFeature(EnumFeatures.Features.ScriptRunner).FirstOrDefault
                (x=> string.Equals(x.Key, "EnableBathExecution")));
        }

        [TestMethod()]
        public void GetValuesParametersByFeatureTest()
        {
            IRuntimeConfigurationReadeable instance = new RuntimeConfigurationReader();

            Assert.IsNotNull(instance.GetValuesParametersByFeature(EnumFeatures.Features.ScriptRunner));
            Assert.IsTrue(instance.GetValuesParametersByFeature(EnumFeatures.Features.ScriptRunner).Any());
            Assert.IsNotNull(instance.GetValuesParametersByFeature(EnumFeatures.Features.ScriptRunner).FirstOrDefault
                (x => string.Equals(x.Key, "AppPoolRestarterScriptPath")));

        }

        [TestMethod()]
        public void PrepareDictionariesWithFlagsTest()
        {
            //
        }

        [TestMethod()]
        public void PrepareDictionariesWithStringsTest()
        {
            //
        }
    }
}

namespace cco.devops.extension.pattern.tfd.ConfigurationSetting.ApplicationSettings
{
    [TestClass()]
    public class RuntimeConfigurationReaderTests
    {
        




    }
}