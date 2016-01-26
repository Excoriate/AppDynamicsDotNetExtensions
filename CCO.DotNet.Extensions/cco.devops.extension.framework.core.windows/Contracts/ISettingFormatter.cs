using System;
using System.Collections.Generic;

namespace cco.devops.extension.framework.core.windows.Contracts
{
    public interface ISettingFormatter<T> where T : AppSettingKeyValueVo, new ()
    {
        List<T> GetKeyValuePairSettingsFormated();
        T GetFormatterValueFromKey(string key);

    }
}
