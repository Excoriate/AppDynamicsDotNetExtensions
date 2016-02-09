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
        

        private static  ConfigurationManager objConfigurationLoader = new ConfigurationManager();

        static void Main(string[] args)
        {


            //Console.WriteLine("AppDynamics Extension Triggered at {0} ", DateTime.Now);

            //if (!object.ReferenceEquals(objConfigurationGlobal, null
            //    ))
            //{
            //    RegisterBasicExecutionInformation(objConfigurationGlobal);
            //    Console.WriteLine("Loading basic information (Operative System, Network, etc.");
                
            //}
            //else
            //{


            //}







        }
            



        
    }
}
