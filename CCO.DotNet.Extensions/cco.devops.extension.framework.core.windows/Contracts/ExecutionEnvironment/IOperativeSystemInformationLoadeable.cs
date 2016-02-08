using cco.devops.extension.transversal.dto.Configuration;
using cco.devops.extension.transversal.dto.ValueObject.Environment; 

namespace cco.devops.extension.framework.core.windows.Contracts.ExecutionEnvironment
{
    public interface IOperativeSystemInformationLoadeable
    {
        EnvironmentConfigurationInformationDto LoadExecutionEnvironmentInformation();
        TrackingUseInformationVo LoadTrackingUseInformation();
        EnvironmentInfoVo LoadEnvironmentInformation();



    }
}
