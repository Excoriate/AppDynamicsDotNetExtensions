
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


        public static void WriteEnabledDisabledFunctions(ConfigurationDto objConfiguration)
        {
            var allConfiguration = new ConfigurationManager().LoadInitialConfiguration();

            if (!object.ReferenceEquals(allConfiguration, null))
            {
                RegisterLogFacade(string.Format("ScriptRunner is: [{0}] \n",
                    allConfiguration.ScripRunnerSettings.IsEnabled ?
                    "Enabled" : "Disabled"), EnumNLogStruct.TypeOfRegister.All,
                    EnumNLogStruct.LogType.Info, true);

                RegisterLogFacade(string.Format("IIS Recycler is: [{0}] \n",
                    allConfiguration.IISRecyclerConfiguration.IsEnabled ?
                    "Enabled" : "Disabled"), EnumNLogStruct.TypeOfRegister.All,
                    EnumNLogStruct.LogType.Info, true);

                RegisterLogFacade(string.Format("IIS Restarter is: [{0}] \n",
                    allConfiguration.IISRestarterConfiguration.IsEnabled ?
                    "Enabled" : "Disabled"), EnumNLogStruct.TypeOfRegister.All,
                    EnumNLogStruct.LogType.Info, true);

                RegisterLogFacade(string.Format("Event Log Manager is: [{0}] \n",
                    allConfiguration.EventLogManager.IsEnabled ?
                    "Enabled" : "Disabled"), EnumNLogStruct.TypeOfRegister.All,
                    EnumNLogStruct.LogType.Info, true);

            }

        }

        /// <summary>
        /// register all type of information when AppDynamics extension is running.  Also, trace
        /// all information from execution environment. 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="option"></param>
        public static void RegisterLogFacade(string message, EnumNLogStruct.TypeOfRegister option, 
            EnumNLogStruct.LogType typeOfLog, bool withPrefix)
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

                        prefix = withPrefix ?
                            $"[AppDynamics CCO Extension on " +
                            $"{objConfigurationGlobal.ExecutionInformation.EnvironmentInfo.MachineHostName} \t" +
                            $"({objConfigurationGlobal.ExecutionInformation.TrackingUsingInfo.IpAddress}) at: \t" +
                            $"{DateTime.Now.ToLongDateString()} says: \n" : string.Empty;
                            ;
                        
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
                var finalMessage = BuildLogInfoWithConfigurationInformation(objConfiguration, false);

                Console.WriteLine(string.Concat(finalMessage, message));
                
                 

            }
        }

        public static string BuildLogInfoWithConfigurationInformation(ConfigurationDto objConfiguration, bool WithAppendLine)
        {
            var objBuilder = default(StringBuilder);

            if (!object.ReferenceEquals(objConfiguration, null))
            {
                objBuilder = new StringBuilder();
                objBuilder.AppendFormat("Hostname: {0} ",
                    objConfiguration.ExecutionInformation.EnvironmentInfo.MachineHostName);

                if (WithAppendLine)
                { 
                    objBuilder.AppendLine() ;
                }
                

                objBuilder.AppendFormat("IPAddress: {0} ",
                    objConfiguration.ExecutionInformation.TrackingUsingInfo.IpAddress);
                if (WithAppendLine)
                {
                    objBuilder.AppendLine() ;
                }

                objBuilder.AppendFormat("SO: {0} ",
                    objConfiguration.ExecutionInformation.EnvironmentInfo.OperativeSystemVersion);
                if (WithAppendLine)
                {
                    objBuilder.AppendLine() ;
                }

                objBuilder.AppendFormat("UserName: {0} ",
                    objConfiguration.ExecutionInformation.TrackingUsingInfo.UserName);
                if (WithAppendLine)
                {
                    objBuilder.AppendLine() ;
                }

                objBuilder.AppendFormat("UserName from Domain: {0} ",
                    objConfiguration.ExecutionInformation.TrackingUsingInfo.UserDomainName);
                if (WithAppendLine)
                {
                    objBuilder.AppendLine() ;
                }

                objBuilder.AppendFormat("Process: {0} ",
                    objConfiguration.ExecutionInformation.TrackingUsingInfo.ProcesorCount);
                //Always will b e a new Line (separator) after the last log register 

            }

            return objBuilder?.ToString();
        }

        private static void RegisterNLogOnly(string message, ConfigurationDto objConfiguration, EnumNLogStruct.LogType typeOfLog)
        {
            var finalMessage = BuildLogInfoWithConfigurationInformation(objConfiguration, false);


            if (!object.ReferenceEquals(objConfiguration, null))
            {
                if (object.ReferenceEquals(objLogger, null))
                {
                    objLogger = new LogManagerContainer().GetAnyInstance<ILoggerConfigurable<Logger>>();
                }

                objLogger.RegisterLogWithCustomInfo(typeOfLog, new LogVo()
                {
                    CustomMessage = string.Concat(finalMessage, message),
                    CustomType    = typeOfLog
                });

            }
        }
    }
}
