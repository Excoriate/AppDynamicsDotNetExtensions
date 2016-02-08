using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using cco.devops.extension.framework.core.windows.ConfigurationSetting;
using cco.devops.extension.clients.appdyn.actionhelper.Configuration;
using cco.devops.extension.pattern.ioc.Containers;
using cco.devops.extension.transversal.logger.Contracts;
using NLog;
using cco.devops.extension.transversal.dto.Configuration;

namespace cco.devops.extension.clients.appdyn.actionhelper
{
    public class Program
    {
        private static  ILoggerConfigurable<Logger> objLogger = new LogManagerContainer().GetAnyInstance
               <ILoggerConfigurable<Logger>>();

        private static  ConfigurationManager objConfigurationLoader = new ConfigurationManager();

        static void Main(string[] args)
        {
            ConfigurationDto objConfigurationGlobal = default(ConfigurationDto); 
            objConfigurationGlobal = new ConfigurationManager().LoadInitialConfiguration();

            if (!object.ReferenceEquals(objConfigurationGlobal, null
                ))
            {
                RegisterBasicExecutionInformation(objConfigurationGlobal);
                
            }
            else
            {


            }







        }

        static void RegisterBasicExecutionInformation(ConfigurationDto objConfiguration)
        {
            

            objLogger.RegisterLogWithCustomInfo(transversal.dto.Enums.Nlog.EnumNLogStruct.LogType.Info,
                new transversal.dto.Log.ValueObject.LogVo()
                {
                    CustomMessage = string.Format("AppDynamics Custom Dot Net Extension Loaded at {0}",
                    DateTime.Now),

                });

            //objLogger.RegisterLogWithCustomInfo(transversal.dto.Enums.Nlog.EnumNLogStruct.LogType.Info,
            //    new transversal.dto.Log.ValueObject.LogVo()
            //    {
            //        CustomMessage = string.Format("Machine {0}",
            //        objConfigurationLoader.LoadInitialConfiguration(),

            //    });

        }



        
    }
}
