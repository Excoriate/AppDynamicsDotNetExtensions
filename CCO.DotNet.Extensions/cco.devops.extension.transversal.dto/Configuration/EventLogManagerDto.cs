using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cco.devops.extension.transversal.dto.Configuration
{
    public sealed class EventLogManagerDto
    {
        public Dictionary<string, bool> Functionality { get; set; }
        public Dictionary<string, string> ValuesParameters { get; set; }
        public bool IsEnabled { get; set; }
    }
}
