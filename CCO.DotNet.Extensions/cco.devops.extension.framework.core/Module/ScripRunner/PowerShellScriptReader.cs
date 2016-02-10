using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using cco.devops.extension.framework.core.Contracts;
using cco.devops.extension.framework.core.Tracker.Log;
using cco.devops.extension.transversal.dto.Enums;
using cco.devops.extension.transversal.dto.Enums.Nlog;
using cco.devops.extension.transversal.logger.NLogConfiguration;
using NLog;

namespace cco.devops.extension.framework.core.Module.ScripRunner
{
    public class PowerShellScriptReader: IScriptShellLoadable
    {
        FileInfo IScriptShellLoadable.LoadSpecificShellScriptFromPath(string path)
        {
            var objInfgo = default(FileInfo);

            if (!string.IsNullOrEmpty(path))
            {
                if (File.Exists(path))
                {
                    objInfgo = new FileInfo(path);

                    new LogTracker().RegisterLogFacade(EnumNLogStruct.LogType.Info, $"Script loaded at: {path}");

                }
            }

            return objInfgo;
        }

        List<FileInfo> IScriptShellLoadable.ListAllScriptsFromPath(string path)
        {
            var filesInDirectory = default(List<FileInfo>);
            var loggerHelper = new LogTracker();

            if (!string.IsNullOrEmpty(path))
            {   
                var auxDirectoryInfo = new DirectoryInfo(path);

                if (auxDirectoryInfo.Exists)
                {
                    loggerHelper.RegisterLogFacade(EnumNLogStruct.LogType.Info, $"Script power shell detected in: {path}");

                    filesInDirectory = new List<FileInfo>(auxDirectoryInfo.GetFiles());

                    if (filesInDirectory.Any())
                    {
                        loggerHelper.RegisterLogFacade(EnumNLogStruct.LogType.Info, $"There are: {filesInDirectory.Count().ToString(CultureInfo.InvariantCulture)} " +
                                                                                    $"script files in folder {path}");

                    }
                    else
                    {
                        loggerHelper.RegisterLogFacade(EnumNLogStruct.LogType.Error, $"Can't find script files in {path}");
                    } 

                }
            }

            return filesInDirectory;
        }

        public bool CheckIfScriptFileIsFromType(EnumScriptRunner.TypeOfScriptFile typeOfScript)
        {
            throw new NotImplementedException();
        }
    }
}
