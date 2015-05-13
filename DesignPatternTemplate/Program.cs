using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternTemplate
{
    class Program
    {
        static void Main(string[] args)
        {
//            //Apdater pattern
//            ITarget target = new AdapterPattern();
//            target.Request();
            //Facade pattern
            FacadePattern facade = new FacadePattern();
            facade.MethodA();
            facade.MethodB();
            Console.ReadLine();
        }
    }
}
