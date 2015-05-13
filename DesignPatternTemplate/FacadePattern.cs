using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternTemplate
{
    public class FacadePattern
    {
        private SubSystemOne subSystemOne;
        private SubSystemTwo subSystemTwo;
        private SubSystemThree subSystemThree;

        public FacadePattern()
        {
            subSystemOne = new SubSystemOne();
            subSystemTwo = new SubSystemTwo();
            subSystemThree = new SubSystemThree();
        }

        public void MethodA()
        {
            Console.WriteLine("MethodA----------");
            subSystemOne.MethodOne();
            subSystemTwo.MethodTwo();
        }

        public void MethodB()
        {
            Console.WriteLine("MethodB----------");
            subSystemThree.MethodThree();
            subSystemTwo.MethodTwo();
        }
    }

    public class SubSystemOne
    {
        public void MethodOne()
        {
            Console.WriteLine("SubSystemOne Method");
        }
    }
    public class SubSystemTwo
    {
        public void MethodTwo()
        {
            Console.WriteLine("SubSystemTwo Method");
        }
    }
    public class SubSystemThree
    {
        public void MethodThree()
        {
            Console.WriteLine("SubSystemThree Method");
        }
    }
}
