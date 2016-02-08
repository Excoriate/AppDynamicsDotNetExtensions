using cco.devops.extension.framework.core.windows.Contracts.ExecutionEnvironment;
using System;
using cco.devops.extension.transversal.dto.Configuration;
using cco.devops.extension.transversal.dto.ValueObject.Environment;
using System.Net;
using System.Net.Sockets;

namespace cco.devops.extension.framework.core.windows.ConfigurationSetting.Runtime.Execution
{
    public class ExecutionInformationReader : IOperativeSystemInformationLoadeable
    {

        public static string GetIPAddress()
        {
            IPHostEntry host;
            string localIP = "?";
            host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    localIP = ip.ToString();
                }
            }
            return localIP;
        }

        public EnvironmentInfoVo LoadEnvironmentInformation()
        {
            return new EnvironmentInfoVo()
            {
                OperativeSystemName = Environment.OSVersion.ToString(),
                OperativeSystemVersion = Environment.OSVersion.Version.Major.ToString(),
                MachineHostName = Environment.MachineName.ToString()

            };
        }

        public EnvironmentConfigurationInformationDto LoadExecutionEnvironmentInformation()
        {
            return new EnvironmentConfigurationInformationDto()
            {
                EnvironmentInfo = this.LoadEnvironmentInformation(),
                TrackingUsingInfo = this.LoadTrackingUseInformation()

            };
        }                                       


        public TrackingUseInformationVo LoadTrackingUseInformation()
        {
            return new TrackingUseInformationVo()
            {
                CommandLine = Environment.CommandLine,
                CurrentDirectory = new System.IO.DirectoryInfo(Environment.CurrentDirectory),
                ProcesorCount = Environment.ProcessorCount.ToString(),
                ExitCodeOfCurrentProcess = Environment.ExitCode.ToString(),
                UserDomainName = Environment.UserDomainName,
                UserName = Environment.UserName,
                UserInteractiveName = Environment.UserInteractive.ToString(),
                ExecutionTime = DateTime.Now,
                IpAddress = GetIPAddress()


            };
        }
    }
}
