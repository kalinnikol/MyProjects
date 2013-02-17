using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01HelloToAll
{
    class HelloToAll
    {
        private static void Hello(string name)
        {
            Console.WriteLine("Hello, {0}!", name);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("What is your name?");
            string name = Console.ReadLine();
            Hello(name);
            Hello("Pesho");
            Hello("Pavka");
            Hello("Rumka");
        }
    }
}
