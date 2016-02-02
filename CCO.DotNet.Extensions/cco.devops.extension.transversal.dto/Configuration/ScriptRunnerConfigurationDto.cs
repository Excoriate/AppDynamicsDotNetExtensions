using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cco.devops.extension.transversal.dto.Configuration
{
    public sealed class ScriptRunnerConfigurationDto
    {
        Dictionary<string, bool> Functionality { get; set; }
        Dictionary<string, string> ValuesParameters { get; set; }
    }
}
