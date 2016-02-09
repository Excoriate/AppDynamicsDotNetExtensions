using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cco.devops.extension.framework.core.iis.Contracts
{
    public interface IISToolsReadeable
    {
        List<string> GetAllApplicationPoolsInCurrentEnvironment();
    }
}
