

namespace cco.devops.extension.transversal.dto.Enums.Features
{
    public struct EnumFeatures
    {
        public enum Features
        {
            ScriptRunner,
            IISRestarter,
            IISRecycler,
            EventLogManager
        }

        public enum Functionality
        {
            ScriptRunnerEnableBathExecution,
            ScriptRunnerEnablePowerShellExecution,
            ScriptRunnerEnableJarExecution
        }

        public enum ValuesParameters
        {
            ScriptRunnerAppPoolRestarterScriptPath,
            ScriptRunnerAppPoolRecyclerScriptPath,
            ScriptRunnerEventSystemLogScripPath
        }
    }
}
