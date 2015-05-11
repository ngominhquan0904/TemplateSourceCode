using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Template.CSharp.Core.ApplicationServices;
using Template.CSharp.Infrastructure.ApplicationServices;

namespace CompostionRoot
{
    public static class DependencyRegistrationExtensions
    {
        public static ContainerBuilder RegisterDenpendency(this ContainerBuilder builder)
        {
            builder.RegisterType<CollectionTmp>().As<ICollectionTmp>().InstancePerRequest();
            builder.RegisterType<CSharpAdvance>().As<ICSharpAdvance>().InstancePerRequest();
            return builder;
        }
    }
}
