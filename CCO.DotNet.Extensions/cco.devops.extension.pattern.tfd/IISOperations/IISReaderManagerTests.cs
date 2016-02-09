using Microsoft.VisualStudio.TestTools.UnitTesting;
using cco.devops.extension.framework.core.iis.IISOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using cco.devops.extension.framework.core.iis.Contracts;

namespace cco.devops.extension.framework.core.iis.IISOperations.Tests
{
    [TestClass()]
    public class IISReaderManagerTests
    {
        [TestMethod()]
        public void GetAllApplicationPoolsInCurrentEnvironmentTest()
        {
            IISToolsReadeable obj = new IISReaderManager();
            Assert.IsNotNull(obj.GetAllApplicationPoolsInCurrentEnvironment());
            Assert.IsTrue(obj.GetAllApplicationPoolsInCurrentEnvironment().Any());
        }
    }
}