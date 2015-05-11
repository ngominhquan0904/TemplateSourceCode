using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Template.CSharp.Core.ApplicationServices;
using Template.CSharp.Infrastructure.ApplicationServices;

namespace Template.Infrastructure.CompositionRoot
{
    public static class DependencyRegistrationExtension
    {
        public static ContainerBuilder RegisterDenpendency(this ContainerBuilder builder)
        {
            builder.RegisterType<CollectionTmp>().As<ICollectionTmp>().InstancePerRequest();
            return builder;
        }
    }
}
