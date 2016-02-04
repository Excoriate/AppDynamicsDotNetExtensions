using cco.devops.extension.transversal.dto.ValueObject.Configuration;
using System;
using System.Collections.Generic;

namespace cco.devops.extension.transversal.dto.Configuration
{
    [Serializable]
    public sealed class ConfigurationDto
    {
        public ScriptRunnerConfigurationDto ScripRunnerSettings { get; set; }


    }
}
