using System;

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

    }
}