using cco.devops.extension.framework.core.windows.Contracts;
using System;
using System.Collections.Generic;  

namespace cco.devops.extension.framework.core.windows.ConfigurationSetting
{
    public class ConfigurationSettingFormatter<T> : ISettingFormatter<T> where T : AppSettingKeyValueVo, new()
    {
        public T GetFormatterValueFromKey(string key)
        {
            throw new NotImplementedException();
        }

        public List<T> GetKeyValuePairSettingsFormated()
        {
            throw new NotImplementedException();
        }
    }
}
