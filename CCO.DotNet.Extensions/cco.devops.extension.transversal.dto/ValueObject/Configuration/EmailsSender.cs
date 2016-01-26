using System;     

namespace cco.devops.extension.transversal.dto.ValueObject.Configuration
{
    [Serializable]
    public sealed class EmailsSender
    {
        public string EmailUser { get;  set; }
        public bool IsEnabled { get; set; }

       
    }
}
