using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cco.devops.extension.transversal.dto.Enums
{
    public struct EnumScriptRunner
    {
        public enum TypeOfScriptFile
        {
            Batch,
            Bat,
            cmdlet,
            Jar,
            PowerShell
        }
    }
}
