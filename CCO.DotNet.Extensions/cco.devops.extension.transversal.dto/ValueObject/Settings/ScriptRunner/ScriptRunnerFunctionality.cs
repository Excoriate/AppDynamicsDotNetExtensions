using System;
using System.Configuration;
using System.Xml;

namespace cco.devops.extension.transversal.dto.ValueObject.Settings.ScriptRunner
{
    public class ScriptRunnerFunctionality: ConfigurationSection
    {
        [ConfigurationProperty("EnableBathExecution")]
        public bool EnableBathExecution { get; set; }
        [ConfigurationProperty("EnablePowerShellExecution")]
        public bool EnablePowerShellExecution { get; set; }

        [ConfigurationProperty("EnableJarExecution")]
        public bool EnableJarExecution {get; set; }


    }
}
