using System; 
using cco.devops.extension.framework.core.Contracts;
using cco.devops.extension.transversal.dto.ValueObject.Scripts;

namespace cco.devops.extension.framework.core.Module.ScripRunner
{
    public class PowerShellScriptRunner:IShellScriptExecutionable
    {
        public void ExecuteShellScript(PowerShellScriptVo shellScript)
        {
            if (!object.ReferenceEquals(shellScript, null))
            {


            }
        }

        public void ExecuteShellScriptWithParameter(PowerShellScriptVo shellScript, params string[] parameters)
        {
            
        }
    }
}
