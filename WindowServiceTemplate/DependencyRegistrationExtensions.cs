using Autofac;
using ServiceStack.Logging;
using ServiceStack.Logging.NLogger;

namespace WindowServiceTemplate
{
    public static class DependencyRegistrationExtensions
    {
        public static IContainer RegisterDependencies(this ContainerBuilder builder)
        {
            builder.RegisterType<NLogFactory>().As<ILogFactory>();
            return builder.Build();
        }
    }
}