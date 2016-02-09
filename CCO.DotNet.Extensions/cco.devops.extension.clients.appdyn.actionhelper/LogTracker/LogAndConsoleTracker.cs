
using System;
using System.Text;
using cco.devops.extension.clients.appdyn.actionhelper.Configuration;
using cco.devops.extension.pattern.ioc.Containers;
using cco.devops.extension.transversal.dto.Configuration;
using cco.devops.extension.transversal.dto.Enums.Nlog;
using cco.devops.extension.transversal.dto.Log.ValueObject;
using cco.devops.extension.transversal.logger.Contracts;
using NLog;

namespace cco.devops.extension.clients.appdyn.actionhelper.LogTracker
{
    

    public static class LogAndConsoleTracker
    {
        private static ILoggerConfigurable<Logger> objLogger = null;


        /// <summary>
        /// register all type of information when AppDynamics extension is running.  Also, trace
        /// all information from execution environment. 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="option"></param>
        public static void RegisterLogFacade(string message, EnumNLogStruct.TypeOfRegister option, EnumNLogStruct.LogType typeOfLog)
        {

            ConfigurationDto objConfigurationGlobal = default(ConfigurationDto);
            objLogger = new LogManagerContainer().GetAnyInstance<ILoggerConfigurable<Logger>>();

            string prefix = default(string);


            if (!string.IsNullOrEmpty(message))
            {
                try
                {

                    objConfigurationGlobal = new ConfigurationManager().LoadInitialConfiguration();

                    if (!object.ReferenceEquals(objConfigurationGlobal, null))
                    {

                        prefix =
                            $"[AppDynamics CCO Extension on " +
                            $"{objConfigurationGlobal.ExecutionInformation.EnvironmentInfo.MachineHostName} " +
                            $"({objConfigurationGlobal.ExecutionInformation.TrackingUsingInfo.IpAddress}) at: " +
                            $"{DateTime.Now.ToLongDateString()} says: "
                            ;

                        Console.WriteLine("{0} all configuration loaded", prefix);
                        var fixedFinalMessage = string.Concat(prefix, message);

                        switch (option)
                        {
                            case EnumNLogStruct.TypeOfRegister.NLog:
                                RegisterNLogOnly(fixedFinalMessage, objConfigurationGlobal, typeOfLog);
                                break;

                            case EnumNLogStruct.TypeOfRegister.Console:
                                RegisterConsoleLog(fixedFinalMessage, objConfigurationGlobal, typeOfLog);
                                break;

                            case EnumNLogStruct.TypeOfRegister.All:
                                RegisterConsoleLog(fixedFinalMessage, objConfigurationGlobal, typeOfLog);
                                RegisterNLogOnly(fixedFinalMessage, objConfigurationGlobal, typeOfLog);
                                break;

                            default:
                                throw new ArgumentOutOfRangeException(nameof(option), option, null);
                        }

                    }
                    else
                    {
                        objLogger.RegisterLogWithCustomInfo(EnumNLogStruct.LogType.Warning, new LogVo()
                        {  
                            CustomMessage = "[AppDynamics CCO Extension]: Cannot load configuration from execution environment"
                        });
                    }

                }
                catch (Exception ex)
                {
                    objLogger.RegisterLogWithCustomInfo(EnumNLogStruct.LogType.Error, new LogVo()
                    {
                        Exception = ex,
                        CustomMessage = ex.Message
                    }); 

                } 
            }
        }

        private static void RegisterConsoleLog(string message, ConfigurationDto objConfiguration, EnumNLogStruct.LogType typeOfLog)
        {
            if (!object.ReferenceEquals(objConfiguration, null))
            {

                



            }
        }

        private static string BuildLogInfoWithConfigurationInformation(ConfigurationDto objConfiguration)
        {
            var objBuilder = default(StringBuilder);

            if (!object.ReferenceEquals(objConfiguration, null))
            {
                objBuilder = new StringBuilder();
                objBuilder.AppendFormat("Hostname: {0}",
                    objConfiguration.ExecutionInformation.EnvironmentInfo.MachineHostName);
                objBuilder.AppendLine();

                objBuilder.AppendFormat("IPAddress: {0}",
                    objConfiguration.ExecutionInformation.TrackingUsingInfo.IpAddress);
                objBuilder.AppendLine();

                objBuilder.AppendFormat("SO: {0}",
                    objConfiguration.ExecutionInformation.EnvironmentInfo.OperativeSystemVersion);
                objBuilder.AppendLine();

                objBuilder.AppendFormat("UserName: {0}",
                    objConfiguration.ExecutionInformation.TrackingUsingInfo.UserName);
                objBuilder.AppendLine();

                objBuilder.AppendFormat("UserName from Domain: {0}",
                    objConfiguration.ExecutionInformation.TrackingUsingInfo.UserDomainName);
                objBuilder.AppendLine();

                objBuilder.AppendFormat("Process: {0}",
                    objConfiguration.ExecutionInformation.TrackingUsingInfo.ProcesorCount);
                objBuilder.AppendLine();

            }

            return objBuilder?.ToString();
        }

        private static void RegisterNLogOnly(string message, ConfigurationDto objConfiguration, EnumNLogStruct.LogType typeOfLog)
        {
            var finalMessage = BuildLogInfoWithConfigurationInformation(objConfiguration);


            if (!object.ReferenceEquals(objConfiguration, null))
            {
                if (object.ReferenceEquals(objLogger, null))
                {
                    objLogger = new LogManagerContainer().GetAnyInstance<ILoggerConfigurable<Logger>>();
                }

                objLogger.RegisterLogWithCustomInfo(typeOfLog, new LogVo()
                {
                    CustomMessage = message,
                    CustomType    = typeOfLog
                });

            }
        }
    }
}
