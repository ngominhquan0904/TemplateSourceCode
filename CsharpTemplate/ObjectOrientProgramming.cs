using System;

namespace CsharpTemplate
{
    public class ObjectOrientProgramming
    {
          
    }

    public class OverloadMethod
    {
        public void DisplayOverload(int i)
        {
            Console.WriteLine("Display Overload Integer "+i);
        }
        public void DisplayOverload(string s)
        {
            Console.WriteLine("Display Overload string "+s);
        }
        public void DisplayOverload(string a,int b)
        {
            Console.WriteLine("Display Overload string and integer "+a+ " "+b);
        }
    }
    public class OverloadOperator
    {
        public int Value;

        public static OverloadOperator operator +(OverloadOperator a, OverloadOperator b)
        {
            var overloadOperator = new OverloadOperator();
            overloadOperator.Value = a.Value + b.Value;
            return overloadOperator;
        }
    }

    public class ClassA
    {
        public void Method1()
        {
            Console.WriteLine("Display method1 classA");
        }
    }

    public class ClassB : ClassA
    {
        public void Method1()
        {
            Console.WriteLine("Display method1 classB");
            base.Method1();
        } 
        public void Method2()
        {
            Console.WriteLine("Display method2 classB");
            base.Method1();
        }
    }

    public class BaseClass
    {
        public void Method1()
        {
            Console.WriteLine("BaseClass Method1");
        }
        public void Method2()
        {
            Console.WriteLine("BaseClass Method2");
        }
        public void Method3()
        {
            Console.WriteLine("BaseClass Method3");
        }
    }
    public class DeriveClass : BaseClass
    {
        public void Method1()
        {
            Console.WriteLine("DeriveClass Method1");
        }
        public void Method2()
        {
            Console.WriteLine("DeriveClass Method2");
        }
        public void Method3()
        {
            Console.WriteLine("DeriveClass Method3");
        }
    }
    public class BaseClass1
    {
        public virtual void Method1()
        {
            Console.WriteLine("BaseClass Method1");
        }
        public virtual void Method2()
        {
            Console.WriteLine("BaseClass Method2");
        }
        public virtual void Method3()
        {
            Console.WriteLine("BaseClass Method3");
        }
    }
    public class DeriveClass1 : BaseClass1
    {
        public override void Method1()
        {
            Console.WriteLine("DeriveClass Method1");
        }
        public new void Method2()
        {
            Console.WriteLine("DeriveClass Method2");
        }
        public void Method3()
        {
            Console.WriteLine("DeriveClass Method3");
        }
    }
    public class BaseClass2
    {
        public void Method1()
        {
            Console.WriteLine("BaseClass Method1");
        }
        public virtual void Method2()
        {
            Console.WriteLine("BaseClass Method2");
        }
        public virtual void Method3()
        {
            Console.WriteLine("BaseClass Method3");
        }
    }
    public class DeriveClass2 : BaseClass2
    {
        public virtual void Method1()
        {
            Console.WriteLine("DeriveClass2 Method1");
        }
        public new void Method2()
        {
            Console.WriteLine("DeriveClass2 Method2");
        }
        public override void Method3()
        {
            Console.WriteLine("DeriveClass2 Method3");
        }
    }
    public class DeriveClass3 : DeriveClass2
    {
        public override void Method1()
        {
            Console.WriteLine("DeriveClass3 Method1");
        }
        public void Method3()
        {
            Console.WriteLine("DeriveClass3 Method3");
        }
    }

    public  class BaseClass4
    {
        public virtual void XXX()
        {
            Console.WriteLine("BaseClass4 XXX");
        }
    }

    public abstract class BaseAbstracClass : BaseClass4
    {
        public new abstract void XXX();
    }
    public class DeriveAbstract : BaseAbstracClass
    {
        public override void XXX()
        {
            Console.WriteLine("DeriveAbstract XXX");
        }
    }
}