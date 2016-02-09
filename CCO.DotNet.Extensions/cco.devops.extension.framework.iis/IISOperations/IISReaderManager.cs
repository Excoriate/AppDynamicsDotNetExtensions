using cco.devops.extension.framework.core.iis.Contracts;
using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Linq;
using System.Text;

namespace cco.devops.extension.framework.core.iis.IISOperations
{
    public class IISReaderManager : IISToolsReadeable
    {
        /// <summary>
        /// List all applications pool from execution environment. 
        /// </summary>
        /// <returns></returns>
        public List<string> GetAllApplicationPoolsInCurrentEnvironment()
        {
            var poolCollections = default(List<string>);
            
            DirectoryEntries appPools =  new DirectoryEntry("IIS://localhost/W3SVC/AppPools").
                Children;
             

            if (!object.ReferenceEquals(appPools, null))
            {
                poolCollections = new List<string>();
                foreach (DirectoryEntry objEntry in appPools)
                {
                    poolCollections.Add(objEntry.Name.ToString());

                }
            }

            return poolCollections;
        }
    }
}
