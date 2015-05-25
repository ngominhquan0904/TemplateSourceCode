using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using Autofac;

namespace WindowServiceTemplate
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<Service1>();
            var container = builder.RegisterDependencies();
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[] 
            { 
                container.Resolve<Service1>()
            };
            ServiceBase.Run(ServicesToRun);
//            Service1 s = new Service1();
//            s.StartGenAppointmentList();
        }
    }
}
