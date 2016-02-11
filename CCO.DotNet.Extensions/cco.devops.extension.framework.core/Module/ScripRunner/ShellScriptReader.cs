using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using cco.devops.extension.framework.core.Contracts;
using cco.devops.extension.framework.core.Tracker.Log;
using cco.devops.extension.transversal.dto.Enums;
using cco.devops.extension.transversal.dto.Enums.Nlog;
using System.Reflection;

namespace cco.devops.extension.framework.core.Module.ScripRunner
{
    public class ShellScriptReader: IScriptShellLoadable
    {
        public FileInfo LoadSpecificShellScriptFromPath(string path)
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

        public List<FileInfo> ListAllScriptsFromPath(string path)
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

        public bool CheckIfScriptFileIsFromType(EnumScriptRunner.TypeOfScriptFile typeOfScript, string path)
        {
            var isFromType = default(bool);
            if (!string.IsNullOrEmpty(path))
            {
                var auxFileInfo = this.LoadSpecificShellScriptFromPath(path);

                if (!object.ReferenceEquals(auxFileInfo, null) &&
                (auxFileInfo.Exists))
                {

                    switch (typeOfScript)
                    {
                        case EnumScriptRunner.TypeOfScriptFile.Bat:
                            isFromType = string.Equals(".bat", auxFileInfo.Extension, 
                                StringComparison.InvariantCultureIgnoreCase);

                            break;

                        case EnumScriptRunner.TypeOfScriptFile.Batch:
                            isFromType = string.Equals(".sh", auxFileInfo.Extension,
                                StringComparison.InvariantCultureIgnoreCase);
                            break;

                        case EnumScriptRunner.TypeOfScriptFile.cmdlet:
                            isFromType = string.Equals(".cmd", auxFileInfo.Extension,
                                StringComparison.InvariantCultureIgnoreCase);
                            break;

                        case EnumScriptRunner.TypeOfScriptFile.PowerShell:
                            isFromType = string.Equals(".ps1", auxFileInfo.Extension,
                                StringComparison.InvariantCultureIgnoreCase);
                            break;

                        case EnumScriptRunner.TypeOfScriptFile.Jar:
                            isFromType = string.Equals(".jar", auxFileInfo.Extension,
                                StringComparison.InvariantCultureIgnoreCase);
                            break; 
                    }

                }

            }   

            return isFromType;
        }

        public DirectoryInfo LoadExecutionDirectoryAssembly()
        {
            var objDirectory = default(DirectoryInfo);
            var pathFromDll = Assembly.GetExecutingAssembly().Location.ToString(CultureInfo.InvariantCulture);
            

            if (!string.IsNullOrEmpty(pathFromDll))
            {
                objDirectory = new DirectoryInfo(pathFromDll);
            }


            return objDirectory;
        }

        public string MakeFullPathFromEnvironmentAndFileName(string fileName)
        {
            var finalPath = default(string);

            if (!string.IsNullOrEmpty(fileName))
            {
                finalPath = Path.Combine(Environment.CurrentDirectory, fileName);
            }

            return finalPath;
        }
    }
}
