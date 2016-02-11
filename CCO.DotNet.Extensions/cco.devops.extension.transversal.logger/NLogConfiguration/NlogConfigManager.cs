
using cco.devops.extension.transversal.dto.Enums.Nlog;
using cco.devops.extension.transversal.dto.Log.ValueObject;
using cco.devops.extension.transversal.logger.Contracts;
using NLog;
using System;

namespace cco.devops.extension.transversal.logger.NLogConfiguration
{
    /// <summary>
    /// #ATR: Main Nlog class for manage logs
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class NlogConfigManager<T> : ILoggerConfigurable<T> where T : Logger
    {
        public Logger MainLogger;
        

        void ILoggerConfigurable<T>.RegisterLog(EnumNLogStruct.LogType typeOfLog, string info)
        {
            if (!string.IsNullOrEmpty(info))
            {
                MainLogger = LogManager.GetCurrentClassLogger();

                switch (typeOfLog)
                {
                    case EnumNLogStruct.LogType.Error:
                        MainLogger.Error(info);
                        break;
                    case EnumNLogStruct.LogType.Fatal:
                        MainLogger.Fatal(info);
                        break;
                    case EnumNLogStruct.LogType.Trace:
                        MainLogger.Trace(info);
                        break;
                    case EnumNLogStruct.LogType.Info:
                        MainLogger.Info(info);
                        break;
                    case EnumNLogStruct.LogType.Warning:
                        MainLogger.Warn(info);
                        break;
                    case EnumNLogStruct.LogType.Debug:
                        MainLogger.Debug(info);
                        break;  
                }
            }
        }

        void ILoggerConfigurable<T>.RegisterLogWithCustomInfo(EnumNLogStruct.LogType typeOfLog, LogVo logInfo)
        {
            if (!object.ReferenceEquals(logInfo, null))
            {
                if (!logInfo.Equals(default(LogVo)))
                {
                    MainLogger = LogManager.GetCurrentClassLogger();

                    switch (typeOfLog)
                    {
                        case EnumNLogStruct.LogType.Error:
                            MainLogger.Error(logInfo.CustomMessage, logInfo.Exception);
                            break;
                        case EnumNLogStruct.LogType.Fatal:
                            MainLogger.Fatal(logInfo.CustomMessage, logInfo.Exception);
                            break;
                        case EnumNLogStruct.LogType.Trace:
                            MainLogger.Trace(logInfo.CustomMessage, logInfo.Exception);
                            break;
                        case EnumNLogStruct.LogType.Info:
                            MainLogger.Info(logInfo.CustomMessage, logInfo.Exception);
                            break;
                        case EnumNLogStruct.LogType.Warning:
                            MainLogger.Warn(logInfo.CustomMessage, logInfo.Exception);
                            break;
                        case EnumNLogStruct.LogType.Debug:
                            MainLogger.Debug(logInfo.CustomMessage, logInfo.Exception);
                            break;
                    }

                }
            }  
        }

        #region Facade Nlog Configuration

        public void RegisterLogFacade(EnumNLogStruct.LogType typeOfLog, string info)
        {
            ((ILoggerConfigurable<T>) this).RegisterLog(typeOfLog, info);
        }

        public void RegisterLogWithCustomInfoFacade(EnumNLogStruct.LogType typeOfLog, LogVo logInfo)
        {
            ((ILoggerConfigurable<T>) this).RegisterLogWithCustomInfo(typeOfLog, logInfo);
        }

        public void RegisterLogWithFatalExceptionFacade(Exception objException, string className)
        {
            ((ILoggerConfigurable<T>)this).RegisterLogWithFatalException(objException, className);

        }

        void ILoggerConfigurable<T>.RegisterLogWithFatalException(Exception objException, string callingClass)
        {
            if (!object.ReferenceEquals(objException, null))
            {
                this.RegisterLogWithCustomInfoFacade
                            (EnumNLogStruct.LogType.Fatal, new transversal.dto.Log.ValueObject.LogVo()
                            {
                                Exception = objException,
                                CustomMessage = $"exception in {callingClass} class",
                                CustomType = EnumNLogStruct.LogType.Fatal
                            }
                            ); 
            }
        }

        #endregion
    }
}
