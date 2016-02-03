using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hi_Lo
{
    class Program
    {
        static void Main(string[] args)
        {
            Random _random = new Random();
            int value = _random.Next(100) + 1;
            int guess = 0;

            do
            {
                guess = Convert.ToInt32(Console.ReadLine());

                if (guess != value)
                {
                    if (guess < value)
                    {
                        Console.WriteLine("Your guess is too low.");
                    }
                    else if (guess > value)
                    {
                        Console.WriteLine("Your guess is too high.");
                    }
                }
                else
                {
                    Console.WriteLine("You got it!");
                }
            } while (guess != value);
        }
    }
}
