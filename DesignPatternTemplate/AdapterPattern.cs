using System;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

namespace DesignPatternTemplate
{
    interface ITarget
    {
        void Request();
    }
    public class AdapterPattern : ITarget
    {
        private Adaptee adaptee = new Adaptee();
        public void Request()
        {
            adaptee.specificRequest();
        }
    }

    public class Adaptee
    {
        public void specificRequest()
        {
            Console.WriteLine("call specific request");
        }
    }
}