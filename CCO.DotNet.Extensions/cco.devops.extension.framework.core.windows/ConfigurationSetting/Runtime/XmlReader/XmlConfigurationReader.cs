using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml;
using cco.devops.extension.framework.core.windows.Contracts;

namespace cco.devops.extension.framework.core.windows.ConfigurationSetting.Runtime.XmlReader
{
    public class XmlConfigurationReader: IRuntimeApplicationConfigurationLoadeable
    {
        public XmlDocument LoadRuntimeConfiguration()
        {
            var objCOnfig   = default(XmlDocument);
            var auxAssembly = (Assembly.GetExecutingAssembly().GetName().CodeBase);

            if (!object.ReferenceEquals(auxAssembly, null))
            {
                var path = new Uri(Path.GetDirectoryName(auxAssembly)).LocalPath;
                if (!object.ReferenceEquals(path, null))
                {
                    objCOnfig = new XmlDocument();
                    objCOnfig.Load(LoadApplicationConfigFromBin(path).FullName);  

                }
            }

            return objCOnfig;
        }

        public XmlDocument LoadRuntimeConfigurationWithPath(string path)
        {
            var objCOnfig   = default(XmlDocument);
            var auxAssembly = (Assembly.GetExecutingAssembly().GetName().CodeBase);

            if (!object.ReferenceEquals(auxAssembly, null) && (!string.IsNullOrEmpty(path)))
            {
                var pathFinal = new Uri(Path.GetDirectoryName(auxAssembly)).LocalPath;
                if (!object.ReferenceEquals(pathFinal, null))
                {
                    objCOnfig = new XmlDocument();
                    objCOnfig.Load(LoadApplicationConfigFromBin(pathFinal).FullName);

                }
            }

            return objCOnfig;
        }

        private static FileInfo LoadApplicationConfigFromBin(string binPath)
        {
            var appConfig = default(FileInfo);

            if (!string.IsNullOrEmpty(binPath))
            {
                var auxDirectoryInfo = new DirectoryInfo(binPath);

                if (auxDirectoryInfo.Exists && auxDirectoryInfo.GetFiles().Any())
                {
                    appConfig = (auxDirectoryInfo.GetFiles().FirstOrDefault(x =>
                        string.Equals(x.Name, "App.config", StringComparison.InvariantCultureIgnoreCase) &&
                        string.Equals(x.Extension, ".config", StringComparison.InvariantCultureIgnoreCase)));

                }
            }

            return appConfig;

        }
    }
}
