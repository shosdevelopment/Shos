using ApiClient;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace ShosBackend.Common.IoC
{
    public class CommonInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Classes.
                    FromThisAssembly()
                    .Pick()
                    .WithServiceDefaultInterfaces()
                    .LifestyleSingleton());

            container.Register(
                Classes.FromAssemblyContaining(typeof(ApiClient<>))
                .Pick()
                .WithServiceDefaultInterfaces()
                .LifestyleSingleton());
        }
    }
}
