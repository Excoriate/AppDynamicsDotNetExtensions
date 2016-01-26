using cco.devops.extension.pattern.ioc.Injector;

namespace cco.devops.extension.pattern.ioc.Containers
{
    public class AppPoolManagerContainer : InjectorContainer
    {
        public override void Load()
        {
            //Bind(typeof(IConfigReadable<>)).To(typeof(AppConfigReader<>));
        }
    }
}
