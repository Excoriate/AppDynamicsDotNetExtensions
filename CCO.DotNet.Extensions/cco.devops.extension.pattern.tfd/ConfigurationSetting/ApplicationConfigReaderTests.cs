using cco.devops.extension.framework.core.windows.ConfigurationSetting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace cco.devops.extension.pattern.tfd.ConfigurationSetting
{
    [TestClass()]
    public class ApplicationConfigReaderTests
    {
        [TestMethod()]
        public void GetAllConfigurationSectionsInConfigTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetAllConfigurationGroupsTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetAnyConfigurationGroupByNameTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetAnySectionByNameTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetAllObjects()
        {
            var instanceToTest = new ApplicationConfigReader();

            Assert.IsTrue(instanceToTest.GetAllConfigurationGroupsObjects().Any());
            Assert.IsTrue(instanceToTest.GetAllConfigurationSectionsObjects().Any());
        }
    }
}