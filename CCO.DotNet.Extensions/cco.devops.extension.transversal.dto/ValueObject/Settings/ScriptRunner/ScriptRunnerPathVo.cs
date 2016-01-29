using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;

namespace cco.devops.extension.transversal.dto.ValueObject.Settings.ScriptRunner
{
    public class ScriptRunnerPathVo : IConfigurationSectionHandler
    {
        public string ScriptNameWithoutExtension { get; set; }
        public string ScriptPath { get; set; }
        public FileInfo ScriptObject { get; set; }

        public object Create(object parent, object configContext, XmlNode section)
        {
            throw new NotImplementedException();
        }
    }
}
