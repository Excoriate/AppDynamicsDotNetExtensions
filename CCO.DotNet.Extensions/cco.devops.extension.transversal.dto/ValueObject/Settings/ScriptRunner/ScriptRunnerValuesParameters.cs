using System;
using System.Collections.Generic;
using System.Configuration; 

namespace cco.devops.extension.transversal.dto.ValueObject.Settings.ScriptRunner
{
    public class ScriptRunnerValuesParameters : ConfigurationSection
    {
        [ConfigurationProperty("AppPoolRestarterScriptPath")]
        public string AppPoolRestarterScriptPath { get; set; }
        [ConfigurationProperty("AppPoolRecyclerScriptPath")]
        public string AppPoolRecyclerScriptPath { get; set; }
        [ConfigurationProperty("EventSystemLogScripPath")]
        public string EventSystemLogScripPath { get; set; }  


    }
}
