using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using cco.devops.extension.transversal.dto.Enums;

namespace cco.devops.extension.framework.core.Contracts
{
    public interface IScriptShellLoadable
    {
        FileInfo LoadSpecificShellScriptFromPath(string path);
        List<FileInfo> ListAllScriptsFromPath(string path);
        bool CheckIfScriptFileIsFromType(EnumScriptRunner.TypeOfScriptFile typeOfScript, string path);
        DirectoryInfo LoadExecutionDirectoryAssembly();

    }
}
