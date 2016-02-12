using cco.devops.extension.framework.core.Contracts;
using cco.devops.extension.framework.core.Module.ScripRunner;
using cco.devops.extension.pattern.ioc.Injector;


namespace cco.devops.extension.pattern.ioc.Containers
{
    public  class ScriptRunnerContainer: InjectorContainer
    {
        public override void Load()
        {
            Bind<IScriptRunnerPlayerable>().To<ScriptRunnerPlayer>();
        }

    }
}
