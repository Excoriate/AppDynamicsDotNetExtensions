
using cco.devops.extension.transversal.dto.ValueObject.Scripts;

namespace cco.devops.extension.framework.core.Contracts
{
    public interface IShellScriptExecutionable
    {
        void ExecuteShellScript(PowerShellScriptVo shellScript);
        void ExecuteShellScriptWithParameter(PowerShellScriptVo shellScript, params string [] parameters);



    }
}
