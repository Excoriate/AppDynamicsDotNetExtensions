using System.Globalization;

namespace cco.devops.extension.framework.core.windows.ConfigurationSetting.ConfigurationHelpers
{
    public class AppConfigHelpers
    {
        /// <summary>
        /// ATR: Get the select
        /// </summary>
        /// <param name="toManipulate"></param>
        /// <param name="spearator"></param>
        /// <param name="firstPartOfArray"></param>
        /// <returns></returns>
        public string GetSplitStringFromConfigByParameter(string toManipulate, char spearator, bool firstPartOfArray)
        {
            var finalString = default(string);

            if (!string.IsNullOrEmpty(toManipulate))
            {
                if (!spearator.Equals(default(char)))
                {
                    finalString = firstPartOfArray
                        ? toManipulate.Split(spearator)[0].ToString(CultureInfo.InvariantCulture)
                        : toManipulate.Split(spearator)[1].ToString(CultureInfo.InvariantCulture);

                }
            }


            return finalString;
        }



    }
}
