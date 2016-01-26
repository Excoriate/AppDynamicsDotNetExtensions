using System;  
using cco.devops.extension.transversal.dto.Enums.Nlog;

namespace cco.devops.extension.transversal.dto.Log.ValueObject
{
    public sealed  class LogVo
    {
        public string CustomMessage { get; set; }
        public EnumNLogStruct.LogType CustomType { get; set; }
        public Exception Exception { get; set; }



    }
}
