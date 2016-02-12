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
using cco.devops.extension.clients.appdyn.actionhelper.LogTracker;
using cco.devops.extension.framework.core.iis.Contracts;
using cco.devops.extension.clients.appdyn.actionhelper.Execution;
using cco.devops.extension.framework.core.Contracts;

namespace cco.devops.extension.clients.appdyn.actionhelper
{
    public class Program
    {   
        

        static void Main(string[] args)
        { 
            LogAndConsoleTracker.RegisterLogFacade("AppDynamics Extension Launched \n", 
                transversal.dto.Enums.Nlog.EnumNLogStruct.TypeOfRegister.All, 
                transversal.dto.Enums.Nlog.EnumNLogStruct.LogType.Info, true);

            var objConfiguration = new ConfigurationManager().LoadInitialConfiguration();

            LogAndConsoleTracker.WriteEnabledDisabledFunctions(objConfiguration);

            TaskRunner(objConfiguration);  
        }

        /// <summary>
        /// Main Task Runner
        /// </summary>
        static void TaskRunner(ConfigurationDto objConfiguration)
        {

            IExecutionable objPlayer = null;

            if (!object.ReferenceEquals(objConfiguration, null))
            {   
                objPlayer = new CoreContainer().GetAnyInstance<IExecutionable>();

                if (!object.ReferenceEquals(objPlayer, null))
                {
                    LogAndConsoleTracker.RegisterLogFacade("Starting Executing features and functions that are enabled... \n",
                        transversal.dto.Enums.Nlog.EnumNLogStruct.TypeOfRegister.All,
                        transversal.dto.Enums.Nlog.EnumNLogStruct.LogType.Info, false);

                }   

            }


            
            


        }   



        
    }
}
