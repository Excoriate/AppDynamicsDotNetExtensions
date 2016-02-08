using System;
using System.Collections.Generic;

namespace cco.devops.extension.transversal.dto.Configuration
{
    public sealed class ScriptRunnerConfigurationDto
    {
        public Dictionary<string, bool> Functionality { get; set; }
        public Dictionary<string, string> ValuesParameters { get; set; }
        public bool IsEnabled { get; set; }
    }
}
