using cco.devops.extension.transversal.dto.ValueObject.Environment;  

namespace cco.devops.extension.transversal.dto.Configuration
{
    public sealed class EnvironmentConfigurationInformationDto
    {
        public EnvironmentInfoVo EnvironmentInfo { get; set; }
        public TrackingUseInformationVo TrackingUsingInfo { get; set; }
    }
}
