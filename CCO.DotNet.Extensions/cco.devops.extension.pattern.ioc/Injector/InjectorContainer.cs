using System.Reflection;
using Ninject;
using Ninject.Modules;
using Ninject.Parameters;

namespace cco.devops.extension.pattern.ioc.Injector
{
    public class InjectorContainer: NinjectModule

    {
        protected IKernel objKernel = null;

        public override void Load()
        {

        }


        public virtual TContract GetAnyInstance<TContract>()
        {
            var injectedInstance = default(TContract);
            
            if (!object.ReferenceEquals(objKernel, null) && !objKernel.Equals(default(StandardKernel)))
            {
                objKernel = default(StandardKernel);
            }

            objKernel = new StandardKernel();

            objKernel.Load(Assembly.GetExecutingAssembly());
            injectedInstance = objKernel.Get<TContract>();

            return injectedInstance;
        }

        public virtual TContract GetAnyInstanceWithConstructorParameter<TContract, TParameter>(TParameter argumentObject, string argumentName)
        {
            var injectedInstanceOf = default(TContract);
            var argumentForConstructor = default(ConstructorArgument);

            if (!argumentObject.Equals(default(TParameter)) && !string.IsNullOrEmpty(argumentName))
            {  
                if (!object.ReferenceEquals(objKernel, null) && !objKernel.Equals(default(StandardKernel)))
                {
                    objKernel = default(StandardKernel);
                }

                argumentForConstructor = new ConstructorArgument(argumentName, argumentObject);

                objKernel = new StandardKernel();

                objKernel.Load(Assembly.GetExecutingAssembly());
                injectedInstanceOf = objKernel.Get<TContract>(argumentForConstructor);

            }

            return injectedInstanceOf;
        }
    }
}
