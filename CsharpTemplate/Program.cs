using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CsharpTemplate
{
    class Program
    {
        static void Main(string[] args)
        {
//            //Overload Method
//            var overloadMethod = new OverloadMethod();
//            overloadMethod.DisplayOverload(2);
//            overloadMethod.DisplayOverload("3");
//            overloadMethod.DisplayOverload("3",3);
            //Overload Operator;

//            var overloadOperator = new OverloadOperator();
//            var a = new OverloadOperator();
//            var b = new OverloadOperator();
//            a.Value = 1;
//            b.Value = 5;
//            overloadOperator = a + b;
//            Console.WriteLine(overloadOperator.Value);
            //Inherit
//            ClassB b = new ClassB();
//            b.Method1();
//            ClassA classA = new ClassA();
//            ClassB classB = new ClassB();
//            classA = classB;
//            classA.Method1();
//            BaseClass x = new BaseClass();
//            DeriveClass y = new DeriveClass();
//            BaseClass z = new DeriveClass();
//            x.Method1();x.Method2();x.Method3();
//            y.Method1();y.Method2();y.Method3();
//            z.Method1();z.Method2();z.Method3();
//              BaseClass1 x = new BaseClass1();
//              DeriveClass1 y = new DeriveClass1();
//              BaseClass1 z = new DeriveClass1();
//            x.Method1();x.Method2();x.Method3();
//            y.Method1();y.Method2();y.Method3();
//            z.Method1();z.Method2();z.Method3();
//             BaseClass2 x = new DeriveClass2();
//            BaseClass2 y = new DeriveClass3();
//            DeriveClass2 z = new DeriveClass3();
//            x.Method1();x.Method2();x.Method3();
//            y.Method1();y.Method2();y.Method3();
//            z.Method1();z.Method2();z.Method3();
//            BaseClass4 x = new DeriveAbstract();
//            BaseAbstracClass y = new DeriveAbstract();
//            x.XXX();
//            y.XXX();
//            CSharpAdvance x = new CSharpAdvance();
//            x.DelegateTemp();
            
      CSharpAdvance x = new CSharpAdvance();
//            x.PluginDelegate();
//            x.MultiDelegate();
//            x.GenericDelegate();
//            x.BaseAction();
//            x.AdvanceAction();
//            x.BaseFunc();
//            x.BaseEvent();
            //
            x.LambdaExpression();
      Console.ReadLine();

        }
    }
}
