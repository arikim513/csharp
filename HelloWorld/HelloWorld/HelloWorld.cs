using System;
using static System.Console;

namespace HelloWorld
{
    class HelloWorld
    {
        static void Main(string[] args)
        {
            if(args.Length == 0)
            {
                Console.WriteLine("How to use : HelloWorld.exe <name>");
                return;
            }

            WriteLine("Hello World! {0}", args[0]);
        }
    }
}