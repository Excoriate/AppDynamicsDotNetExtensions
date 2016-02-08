using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cco.devops.extension.transversal.dto.ValueObject.Environment
{
    public sealed class EnvironmentInfoVo
    {
        public string OperativeSystemName { get; set; }
        public string OperativeSystemVersion { get; set; }
        public string MachineHostName { get; set; }
    }
}
