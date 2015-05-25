using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography.X509Certificates;

namespace CsharpTemplate
{
    public class CSharpAdvance
    {
        #region Delegate
        public delegate int Transformer(int x);
        public delegate void ProgressWrite(int x);
        public delegate T GenericTransformer<T>(T arg);
        public void DelegateTemp()
        {
            Transformer t = Square;
            int result = t(3);
            Console.WriteLine(result);
        }

        public void PluginDelegate()
        {
            int[] values = { 1, 2, 3 };
            DelegateResult(values, Square);
            for (int i = 0; i < values.Length; i++)
            {
                Console.WriteLine("value " + (i + 1) + " is " + values[i]);
            }
        }

        public void MultiDelegate()
        {
            ProgressWrite p = PrintDelegate1;
            p += PrintDelegate2;
            PrintDelegate(p);
        }

        public void GenericDelegate()
        {
            int[] values = {2, 3, 4};
            Transform(values,Square);
            for (int i = 0; i < values.Length; i++)
            {
                Console.WriteLine(values[i]);
            }
        }

        public void Transform<T>(T[] values, GenericTransformer<T> t)
        {
            for (int i = 0; i < values.Length; i++)
            {
                values[i] = t(values[i]);
            }
        }
        public void PrintDelegate(ProgressWrite p)
        {
            for (int i = 0; i <= 3; i++)
            {
                p(i);
            }
        }
        public void PrintDelegate1(int i)
        {
            Console.WriteLine(i * 2);
        }
        public void PrintDelegate2(int i)
        {
            Console.WriteLine(i * 3);
        }
        public int Square(int x)
        {
            return x * x;
        }

        public void DelegateResult(int[] values, Transformer t)
        {
            for (int i = 0; i < values.Length; i++)
            {
                values[i] = t(values[i]);
            }
        } 
        #endregion
        #region Action

        public void BaseAction()
        {
            Action<int> action = (int x) => Console.WriteLine("Value {0}", x);
            action.Invoke(5);
        }

        public void AdvanceAction()
        {
            Dictionary<string,Action> example = new Dictionary<string, Action>();
            example["cat"] = Cat;
            example["dog"] = Dog;
            example["cat"].Invoke();
            example["dog"].Invoke();
        }

        static void Cat()
        {
            Console.WriteLine("this is Cat");
        }
        static void Dog()
        {
            Console.WriteLine("this is Dog");
        }
        #endregion

        #region Func

        public void BaseFunc()
        {
            Func<bool, int, string> message = (b, x) => string.Format("string = {0} and {1}", b, x);
            Console.WriteLine(message.Invoke(true, 3));
        }

        #endregion
        #region Event -- not complete,continue to study

        public delegate void EventHandler();
        public static  event EventHandler _show;
        public void BaseEvent()
        {
           _show += new EventHandler(Cat);
            _show += new EventHandler(Dog);
            _show.Invoke();
        }

        #endregion

        #region Lambda Expression

        private static Func<int> Natural()
        {
//            int seed = 0;
//            return () => seed++;

            return () =>
            {
                int seed = 0;
                return seed++;
            };
        }

        public void LambdaExpression()
        {
            Func<int> natural = Natural();
            Console.WriteLine(natural());
            Console.WriteLine(natural());
        }

        public void LambdaExpression1()
        {
            Action[] actions = new Action[3];
            int i = 0;
            foreach (char c in "abc")
            {
                actions[i++] = () => Console.WriteLine(c);
            }
            foreach (Action action in actions)
            {
                action();
            }
            //Action[] actions1 = new Action[3];
            //for (int j = 0; j < 3; j++)
            //{
            //    actions1[j] = () => Console.WriteLine(j);
            //}
            //foreach (var action1 in actions1)
            //{
            //    action1();
            //}
            
        }
        #endregion
        #region Dynamic type

        public dynamic y;

        public void DynamicTypeTemp()
        {
            dynamic a = 1;
            Console.WriteLine(a);
            a = new string[0];
            Console.WriteLine(a);
            a = Test();
            Console.WriteLine(a);
        }

        public dynamic Test()
        {
            return 10;
        }
        #endregion
    }
}