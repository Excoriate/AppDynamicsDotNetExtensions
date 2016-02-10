using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using cco.devops.extension.framework.core.Contracts;
using cco.devops.extension.transversal.dto.ValueObject.Scripts;

namespace cco.devops.extension.framework.core.Module.ScripRunner
{
    public class PowerShellScriptRunner:IShellScriptExecutionable
    {
        void IShellScriptExecutionable.ExecuteShellScript(PowerShellScriptVo shellScript)
        {
            throw new NotImplementedException();
        }

        void IShellScriptExecutionable.ExecuteShellScriptWithParameter(PowerShellScriptVo shellScript, params string[] parameters)
        {
            throw new NotImplementedException();
        }
    }
}
