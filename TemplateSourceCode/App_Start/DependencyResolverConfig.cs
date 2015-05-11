using System.Reflection;
using System.Web.Mvc;
using Autofac;
using Autofac.Core;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using WebGrease.Configuration;
using System.Web.Http;
using CompostionRoot;
namespace TemplateSourceCode
{
    public static class DependencyResolverConfig
    {
        public static void Register()
        {
            var container = Container();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

        private static ILifetimeScope Container()
        {
            return new ContainerBuilder().RegisterMvcController().RegisterDenpendency().Build();
        }

        private static ContainerBuilder RegisterMvcController(this ContainerBuilder builder)
        {
            var excuteAssembly = Assembly.GetExecutingAssembly();
            builder.RegisterControllers(excuteAssembly);
            builder.RegisterApiControllers(excuteAssembly);
            builder.RegisterFilterProvider();
            return builder;
        }
    }
}