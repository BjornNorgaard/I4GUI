using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invers_Hi_Lo
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int guess = 0, lowest = 1, highest = 100, numberOfTurns = 0;
            ConsoleKeyInfo consoleKeyInfo;

            Console.WriteLine("Think of a number between 1 and 100.\nI will make a guess.\n");
            guess = random.Next(100) + 1;

            do
            {
                Console.WriteLine("I guess {0}.\n Is it (h)igher, (e)qual or (l)ower?", guess);
                numberOfTurns++;
                consoleKeyInfo = Console.ReadKey(true);

                if (consoleKeyInfo.Key == ConsoleKey.H)
                {
                    lowest = guess;
                    guess = random.Next(highest - lowest) + lowest;
                }
                else if (consoleKeyInfo.Key == ConsoleKey.L)
                {
                    highest = guess;
                    guess = random.Next(highest - lowest) + lowest;
                }
                else if (consoleKeyInfo.Key == ConsoleKey.E)
                {
                    Console.WriteLine("Hurray I got it, in {0} turns!", numberOfTurns);
                }
            } while (consoleKeyInfo.Key != ConsoleKey.E);
        }
    }
}
