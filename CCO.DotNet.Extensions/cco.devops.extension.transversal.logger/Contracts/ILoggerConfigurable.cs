
using cco.devops.extension.transversal.dto.Enums.Nlog;
using cco.devops.extension.transversal.dto.Log.ValueObject;
using NLog;
using System;

namespace cco.devops.extension.transversal.logger.Contracts
{
    public interface ILoggerConfigurable<T> where T : Logger

    {
        void RegisterLog(EnumNLogStruct.LogType typeOfLog, string info);
        void RegisterLogWithCustomInfo(EnumNLogStruct.LogType typeOfLog, LogVo logInfo);
        void RegisterLogWithFatalException(Exception objException, string className);
    }
}
