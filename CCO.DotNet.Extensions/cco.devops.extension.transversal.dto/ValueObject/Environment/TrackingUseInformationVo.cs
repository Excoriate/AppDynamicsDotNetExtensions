using System;        
using System.IO; 

namespace cco.devops.extension.transversal.dto.ValueObject.Environment
{
    public class TrackingUseInformationVo
    {
        public  string ProcesorCount { get; set; }
        public  string CommandLine { get; set; }
        public DirectoryInfo CurrentDirectory { get; set; }
        public string ExitCodeOfCurrentProcess { get; set; }
        public string UserDomainName { get; set; }
        public string UserName { get; set; }
        public string UserInteractiveName{ get; set; }
        public DateTime ExecutionTime { get; set; }
        public string IpAddress { get; set; }



    }
}
