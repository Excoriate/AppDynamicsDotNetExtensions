using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using cco.devops.extension.transversal.dto.Enums.Nlog;
using cco.devops.extension.transversal.dto.ValueObject;
using NLog;

namespace cco.devops.extension.transversal.logger.Contracts
{
    public interface ILoggerConfigurable<T> where T : Logger

    {
        void RegisterLog(EnumNLogStruct.LogType typeOfLog, string info);
        void RegisterLogWithCustomInfo(EnumNLogStruct.LogType typeOfLog, LogVo logInfo);

    }
}
