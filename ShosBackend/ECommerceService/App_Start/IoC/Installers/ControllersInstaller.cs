using System.Web.Http;
using System.Web.Mvc;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using ECommerceService.App_Start.IoC.Plumbing;

namespace ECommerceService.App_Start.IoC.Installers
{
	public class ControllersInstaller : IWindsorInstaller
	{
		public void Install(IWindsorContainer container, IConfigurationStore store)
		{
			container.Register(
				Classes.
					FromThisAssembly().
					BasedOn<IController>().
					If(c => c.Name.EndsWith("Controller")).
					LifestyleTransient());

			container.Register(
				Classes
					.FromThisAssembly()
					.BasedOn<ApiController>()
					.LifestyleScoped()
				);

			ControllerBuilder.Current.SetControllerFactory(new WindsorControllerFactory(container));
		}
	}
}