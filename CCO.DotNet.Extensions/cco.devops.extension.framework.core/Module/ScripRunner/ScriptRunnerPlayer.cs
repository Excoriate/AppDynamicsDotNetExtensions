using cco.devops.extension.framework.core.Contracts;
using cco.devops.extension.framework.core.Tracker.Log;
using System;

namespace cco.devops.extension.framework.core.Module.ScripRunner
{
    public class ScriptRunnerPlayer : IScriptRunnerPlayerable
    {

        public bool RunRecycleApplicationPoolByOrder()
        {
            var runIsOk = default(bool);
            const string fileName = "Script_IISAppPoolRecyclerBat.Bat";
            var loggerHelper = new LogTracker();
            IScriptShellLoadable objLoader = new ShellScriptReader();
            IShellScriptExecutionable objRunner = new ShellScriptRunner();

            var fullPathForScript = objLoader.MakeFullPathFromEnvironmentAndFileName(fileName);

            if (!string.IsNullOrEmpty(fullPathForScript))
            {
                var scriptInfo = objLoader.LoadSpecificShellScriptFromPath(fullPathForScript);

                if (objLoader.CheckIfScriptFileIsFromType(transversal.dto.Enums.EnumScriptRunner.TypeOfScriptFile.Bat,
                    fullPathForScript) && (scriptInfo.Exists))
                {
                    runIsOk = objRunner.ExecuteBatThatTriggerPowerShell(new transversal.dto.ValueObject.
                        Scripts.PowerShellScriptVo()
                    {
                        FileName = fullPathForScript,
                        ScriptFileObject = scriptInfo
                    });

                    if (runIsOk)
                    {
                        loggerHelper.RegisterLogFacade(transversal.dto.Enums.Nlog.EnumNLogStruct.LogType.Info,
                        "file: Script_IISAppPoolRecyclerBat executed OK");
                    }   
                }
            } 
               
            return runIsOk;
        }
    }
}
