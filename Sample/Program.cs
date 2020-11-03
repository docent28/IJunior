using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World");
            SomeClass instnce = new SomeClass();
            Console.WriteLine(SomeClass.StaticField);
        }
    }

    class SomeClass
    {
        public static float StaticField;

        static SomeClass()
        {
            StaticField = 10;
            Console.WriteLine("Static ctor");
        }

        public SomeClass()
        {
            Console.WriteLine("ctor");
        }
    }
}
