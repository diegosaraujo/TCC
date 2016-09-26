[assembly: WebActivator.PostApplicationStartMethod(typeof(ProjetoDDD.UI.Mvc.App_Start.SimpleInjectorInitializer), "Initialize")]

namespace ProjetoDDD.UI.Mvc.App_Start
{
    using System.Reflection;
    using System.Web.Mvc;

    using SimpleInjector;
    using SimpleInjector.Extensions;
    using SimpleInjector.Integration.Web;
    using SimpleInjector.Integration.Web.Mvc;
    using Application;
    using Application.Interfaces;
    using Domain.Interfaces.Service;
    using Domain.Services;
    using Domain.Interfaces.Repository;
    using Infra.Data.Repository;
    using Infra.Data.Interfaces;
    using Infra.Data.UoW;
    using Infra.Data.Context;

    public static class SimpleInjectorInitializer
    {
        /// <summary>Initialize the container and register it as MVC3 Dependency Resolver.</summary>
        public static void Initialize()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();
            
            InitializeContainer(container);

            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());
            
            container.Verify();
            
            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }
     
        private static void InitializeContainer(Container container)
        {
            /*container.Register<IClienteAppService, ClienteAppService>(Lifestyle.Scoped);
            container.Register<IClienteService, ClienteService>(Lifestyle.Scoped);
            container.Register<IClienteRepository, ClienteRepository>(Lifestyle.Scoped);
            container.Register<ILivroRepository, LivroRepository>(Lifestyle.Scoped);
            container.Register<IUnitOfWork, UnitOfWork>(Lifestyle.Scoped);*/
            container.RegisterPerWebRequest<IClienteAppService, ClienteAppService>();
            container.RegisterPerWebRequest<IClienteService, ClienteService>();
            container.RegisterPerWebRequest<IClienteRepository, ClienteRepository>();
            container.RegisterPerWebRequest<ILivroRepository, LivroRepository>();
            container.RegisterPerWebRequest<IUnitOfWork, UnitOfWork>();

            container.RegisterPerWebRequest<ProjetoDDDContext>();
            //#error Register your services here (remove this line).

            // For instance:
            // container.Register<IUserRepository, SqlUserRepository>(Lifestyle.Scoped);
        }
    }
}