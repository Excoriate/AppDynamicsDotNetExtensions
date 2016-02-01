using cco.devops.extension.framework.core.windows.ConfigurationSetting.Runtime;
using cco.devops.extension.framework.core.windows.ConfigurationSetting.Runtime.XmlReader;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace cco.devops.extension.pattern.tfd.ConfigurationSetting.Runtime
{
    [TestClass()]
    public class RuntimeConfigurationManagerTests
    {
        [TestMethod()]
        public void LoadRuntimeConfigurationTest()
        {
            var objTet = new XmlConfigurationReader()
                .LoadRuntimeConfiguration();
        }

        [TestMethod()]
        public void LoadRuntimeConfigurationWithPathTest()
        {
            Assert.Fail();
        }
    }
}