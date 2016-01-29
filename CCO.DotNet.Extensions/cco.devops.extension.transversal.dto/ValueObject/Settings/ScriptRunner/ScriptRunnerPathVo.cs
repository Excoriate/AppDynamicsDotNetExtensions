using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace cco.devops.extension.transversal.dto.ValueObject.Settings.ScriptRunner
{
    public class ScriptRunnerPathVo
    {
        public string ScriptNameWithoutExtension { get; set; }
        public string ScriptPath { get; set; }
        public FileInfo ScriptObject { get; set; }
    }
}
