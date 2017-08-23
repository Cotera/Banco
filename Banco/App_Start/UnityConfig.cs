using Banco.Controllers;
using Banco.Service;
using Banco.Repository;
using Microsoft.Practices.Unity;
using System.Web.Http;
using Unity.WebApi;

namespace Banco
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

			// register all your components with the container here
			// it is NOT necessary to register your controllers
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
            container.RegisterType<IPersonasService, PersonasService>();
            container.RegisterType<IPersonasRepository, PersonasRepository>();
            container.RegisterType<ICuentaBancariaService,CuentaBancariaService>();
            container.RegisterType<ICuentaBancariaRepository, CuentaBancariaRepository>();
			container.RegisterType<IDomicilioRepository, DomicilioRepository>();
			container.RegisterType<IDomicilioService, DomicilioService>();
        }
    }
}