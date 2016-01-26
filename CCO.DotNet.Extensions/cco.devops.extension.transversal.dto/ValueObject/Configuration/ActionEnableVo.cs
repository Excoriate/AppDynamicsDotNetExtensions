using System; 

namespace cco.devops.extension.transversal.dto.ValueObject.Configuration
{
    [Serializable]
    public sealed class ActionEnableVo

    {
        public string ActionName {get; set; }
        public bool IsEnabled { get; set; }   
    }
}
