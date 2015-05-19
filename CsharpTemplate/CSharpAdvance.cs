using System;

namespace CsharpTemplate
{
    public class CSharpAdvance
    {
        public delegate int Transformer(int x);

        public void DelegateTemp()
        {
            Transformer t = Square;
            int result = t(3);
            Console.WriteLine(result);
        }

        public void PluginDelegate()
        {
            int[] values = {1, 2, 3};
            DelegateResult(values, Square);
            for (int i = 0; i < values.Length; i++)
            {
                Console.WriteLine("value "+i+" is "+values[i]);
            }
        }
        public int Square(int x)
        {
            return x*x;
        }

        public int DelegateResult(int[] values, Transformer t)
        {
            for (int i = 0; i < values.Length; i++)
            {
                values[i] = t(values[i]);
            }
        }
    }
}