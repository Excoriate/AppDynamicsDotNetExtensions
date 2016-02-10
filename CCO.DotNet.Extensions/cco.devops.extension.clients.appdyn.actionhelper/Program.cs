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

namespace cco.devops.extension.clients.appdyn.actionhelper
{
    public class Program
    {   
        

        static void Main(string[] args)
        { 
            LogAndConsoleTracker.RegisterLogFacade("AppDynamics Extension Launched \n", 
                transversal.dto.Enums.Nlog.EnumNLogStruct.TypeOfRegister.All, 
                transversal.dto.Enums.Nlog.EnumNLogStruct.LogType.Info, true);

            TaskRunner();  
        }

        /// <summary>
        /// Main Task Runner
        /// </summary>
        static void TaskRunner()
        {
            LogAndConsoleTracker.WriteEnabledDisabledFunctions(new ConfigurationManager().LoadInitialConfiguration());
            Console.ReadKey();

            //var algo = new AppPoolManagerContainer().GetAnyInstance<IISToolsReadeable>().GetAllApplicationPoolsInCurrentEnvironment();
            //foreach (var item in algo)
            //{
            //    Console.WriteLine(item);
            //}

        }   



        
    }
}
