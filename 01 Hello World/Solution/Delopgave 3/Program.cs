using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delopgave_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter 1st number: ");
            int a = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter 2st number: ");
            int b = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("The sum of {0} and {1} is: {2}", a, b, b + a);
        }
    }
}
