using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cco.devops.extension.transversal.dto.Enums.Nlog
{
    public struct EnumNLogStruct
    {
        public enum LogType
        {
            Error,
            Fatal,
            Trace,
            Info, 
            Warning,
            Debug
        }
    }
}
