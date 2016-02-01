using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace cco.devops.extension.framework.core.windows.Contracts
{
    public interface IRuntimeApplicationConfigurationLoadeable
    {
        XmlDocument LoadRuntimeConfiguration();
        XmlDocument LoadRuntimeConfigurationWithPath(string path);

    }
}
