using cco.devops.extension.framework.core.windows.Contracts.ConfigurationSetting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace cco.devops.extension.framework.core.windows.ConfigurationSetting.Runtime.ConfigurationLoader.Tests
{
    [TestClass()]
    public class RuntimeConfigurationLoaderTests
    {
        [TestMethod()]
        public void LoadEventLogManagerConfigurationTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void LoadIISRecyclerConfigurationTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void LoadIISRestarterCondfigurationTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void LoadScriptRunnerConfigurationTest()
        {
            IConfigurationLoadeable objTest = new RuntimeConfigurationLoader();
            Assert.IsNotNull(objTest.LoadScriptRunnerConfiguration());
            Assert.IsTrue(objTest.LoadScriptRunnerConfiguration().Functionality.Any());
            Assert.IsTrue(objTest.LoadScriptRunnerConfiguration().ValuesParameters.Any());

        }
    }
}