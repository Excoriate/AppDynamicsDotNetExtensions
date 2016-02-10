using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace cco.devops.extension.transversal.dto.ValueObject.Scripts
{
    public sealed class PowerShellScriptVo
    {
        public FileInfo ScriptFileObject { get; set; }
        public string FileName { get; set; } 
    }
}
