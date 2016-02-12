using System;
using cco.devops.extension.framework.core.Contracts;
using cco.devops.extension.transversal.dto.ValueObject.Scripts;
using cco.devops.extension.transversal.dto.Enums.Nlog;
using cco.devops.extension.framework.core.Tracker.Log;
using System.Diagnostics;

namespace cco.devops.extension.framework.core.Module.ScripRunner
{
    public class ShellScriptRunner :IShellScriptExecutionable
    {
        public bool ExecuteBatThatTriggerPowerShell(PowerShellScriptVo shellScript)
        {
            var executeOk = default(bool);
            IScriptShellLoadable objLoader = default(IScriptShellLoadable);
            var loggerHelper = new LogTracker();

            if (!object.ReferenceEquals(shellScript, null))
            {
                objLoader = new ShellScriptReader();

                if (objLoader.CheckIfScriptFileIsFromType(transversal.dto.Enums.EnumScriptRunner.TypeOfScriptFile.Bat,
                    shellScript.ScriptFileObject.FullName))
                {
                    loggerHelper.RegisterLogFacade(EnumNLogStruct.LogType.Info,
                        $"Loaded script: {shellScript.FileName} " +
                     $"from Folder {shellScript.FileName} and Type {shellScript.ScriptFileObject.Extension}");

                    try
                    {
                        var objProcess = new Process()
                        {
                            StartInfo =
                                {
                                    FileName = shellScript.ScriptFileObject.FullName,
                                    Arguments = shellScript.ScriptFileObject.FullName,
                                    UseShellExecute = false,
                                    RedirectStandardOutput = true,
                                    RedirectStandardError = true

                                }
                        };

                        executeOk = string.IsNullOrEmpty(objProcess.StandardError.ReadToEnd());

                    }
                    catch (Exception ex)
                    {
                        loggerHelper.RegisterLogWithFatalExceptionFacade(ex, this.GetType().
                            Name);
                    }
                }


            }

            return executeOk; 
        }

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
