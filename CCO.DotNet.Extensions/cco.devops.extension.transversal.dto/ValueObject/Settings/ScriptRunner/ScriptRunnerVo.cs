using System;
using System.Configuration;
using System.Xml;

namespace cco.devops.extension.transversal.dto.ValueObject.Settings.ScriptRunner
{
    public class ScriptRunnerVo: IConfigurationSectionHandler
    {
        public string ScriptActionName { get; set; }
        public bool IsEnabled { get; set; }

        public object Create(object parent, object configContext, XmlNode section)
        {
            throw new NotImplementedException();
        }
    }
}
