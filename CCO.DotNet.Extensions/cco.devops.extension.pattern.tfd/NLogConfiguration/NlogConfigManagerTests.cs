using cco.devops.extension.pattern.ioc.Containers;
using cco.devops.extension.transversal.dto.Enums.Nlog;
using cco.devops.extension.transversal.logger.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NLog;

namespace cco.devops.extension.pattern.tfd.NLogConfiguration
{
    [TestClass()]
    public class NlogConfigManagerTests
    {
        [TestMethod()]
        public void RegisterLogFacadeTest()
        {
            var objContainer = new ToolsContainer();
            var instance = objContainer.GetAnyInstance<ILoggerConfigurable<Logger>>();

            Assert.IsNotNull(instance);

            instance.RegisterLog(EnumNLogStruct.LogType.Info, "info test message");
            instance.RegisterLog(EnumNLogStruct.LogType.Error, "Error test message");
            instance.RegisterLog(EnumNLogStruct.LogType.Warning, "warnming test message");

            


        }

        [TestMethod()]
        public void RegisterLogWithCustomInfoFacadeTest()
        {
            Assert.Fail();
        }
    }
}