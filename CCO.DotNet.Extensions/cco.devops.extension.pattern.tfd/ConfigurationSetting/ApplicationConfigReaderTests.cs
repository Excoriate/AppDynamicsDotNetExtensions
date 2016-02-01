using System;
using System.Configuration;
using System.IO;
using cco.devops.extension.framework.core.windows.ConfigurationSetting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Reflection;
using cco.devops.extension.framework.core.windows.ConfigurationSetting.ApplicationSettings;

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
            var instanceToTest = new CustomSectionsApplicationReader();

            Assert.IsTrue(instanceToTest.GetAllConfigurationGroupsObjects().Any());
            Assert.IsTrue(instanceToTest.GetAllConfigurationSectionsObjects().Any());

            var allConfigSections = (instanceToTest.GetAllConfigurationSectionsObjects()).
                FirstOrDefault(x=> string.Equals(x.SectionInformation.Name,
                "scriptPaths"));

            var allGropusNames = instanceToTest.GetAllConfigurationGroupsObjects().Select(
                x => x.SectionGroupName).ToList();

            var allConfigSectionsNames = (instanceToTest.GetAllConfigurationSectionsObjects()).
                Select(x => x.SectionInformation.Name
                ).ToList();

            
            //map.MachineConfigFilename = Assembly.GetExecutingAssembly().Location
            //var pathWhereIsAppConfig = new DirectoryInfo(Assembly.GetExecutingAssembly().Location);

            //if (!object.ReferenceEquals(pathWhereIsAppConfig, null))
            //{
            //    var debugFolder = new DirectoryInfo(pathWhereIsAppConfig.Parent.ToString());
            //    var debugFolderValidated = !debugFolder.Exists
            //        ? new DirectoryInfo(debugFolder.Parent.FullName)
            //        : debugFolder; 

            //    if (debugFolderValidated.Exists    )
            //    {
            //        var appConfigFile = (debugFolderValidated.GetFiles().FirstOrDefault(x=> 
            //        string.Equals(x.Name, "App.config", StringComparison.InvariantCultureIgnoreCase) &&
            //        string.Equals(x.Extension, ".config", StringComparison.InvariantCultureIgnoreCase)));

            //        if (!object.ReferenceEquals(appConfigFile, null))
            //        {
            //            ExeConfigurationFileMap map = new ExeConfigurationFileMap
            //            {
            //                ExeConfigFilename = appConfigFile.FullName,
            //                MachineConfigFilename = appConfigFile.FullName ,
            //                LocalUserConfigFilename = appConfigFile.FullName
            //            };

            //            //var name = appConfigFile.FullName.Split('')

            //            //var appConfigObject = ConfigurationManager.OpenMappedExeConfiguration(map,
            //            //    ConfigurationUserLevel.None);

            //            //Uri UriAssemblyFolder = new Uri(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase));
            //            //string appPath = UriAssemblyFolder.LocalPath;

            //            var appConfigObject = ConfigurationManager.OpenExeConfiguration(appConfigFile.FullName);

            //        }

                    
            //    }
            //}

            //Assert.IsTrue(pathWhereIsAppConfig.Exists);

            //var appConfigToLoad = pathWhereIsAppConfig.GetFiles().FirstOrDefault(x => string.Equals(x.Extension,
            //    ".config", StringComparison.InvariantCultureIgnoreCase) && (string.Equals(x.Name,
            //        "app", StringComparison.InvariantCultureIgnoreCase)));

            //Assert.IsNotNull(appConfigToLoad);

            //map.MachineConfigFilename = appConfigToLoad.FullName;

            
            //D:\Dropbox\SOURCE-GitHub\cencosud\AppDynamicsDotNetExtensions\CCO.DotNet.Extensions\cco.devops.extension.pattern.tfd\bin\Debug\cco.devops.extension.pattern.tfd.dll

          /*  var appConfig = ConfigurationManager.OpenMappedExeConfiguration(map, ConfigurationUserLevel.None)*/;
            



        }
    }
}