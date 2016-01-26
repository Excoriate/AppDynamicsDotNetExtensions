using System;

namespace cco.devops.extension.transversal.dto.ValueObject.Configuration
{
    [Serializable]
    public sealed class CommunicationFunctionsVo
    {
        public string Communication { get; set; }
        public bool IsEnabled { get; set; }
    }
}
