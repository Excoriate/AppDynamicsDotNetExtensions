using Microsoft.VisualStudio.TestTools.UnitTesting;
using cco.devops.extension.clients.appdyn.actionhelper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cco.devops.extension.clients.appdyn.actionhelper.Configuration.Tests
{
    [TestClass()]
    public class ConfigurationManagerTests
    {
        [TestMethod()]
        public void LoadInitialConfigurationTest()
        {
            var confiTest = new ConfigurationManager();
            Assert.IsNotNull(confiTest.LoadInitialConfiguration());

        }
    }
}