using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace if_else_switch
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            // Football match outcome determination using if-else statements

            Console.WriteLine("Football match outcome determination using if-else statements:");

            Console.WriteLine("Enter the score of Team A:");
            int scoreAIfElse = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter the score of Team B:");
            int scoreBIfElse = Convert.ToInt32(Console.ReadLine());

            if (scoreAIfElse > scoreBIfElse)
            {
                Console.WriteLine("Team A wins!");
            }
            else if (scoreBIfElse > scoreAIfElse)
            {
                Console.WriteLine("Team B wins!");
            }
            else
            {
                Console.WriteLine("It's a draw!");
            }

            Console.WriteLine();

            // Football match outcome determination using switch statements

            Console.WriteLine("Football match outcome determination using switch statements:");

            Console.WriteLine("Enter the score of Team A:");
            int scoreASwitch = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter the score of Team B:");
            int scoreBSwitch = Convert.ToInt32(Console.ReadLine());

            int scoreDifference = scoreASwitch - scoreBSwitch;

            switch (scoreDifference)
            {
                case > 0:
                    Console.WriteLine("Team A wins!");
                    break;
                case < 0:
                    Console.WriteLine("Team B wins!");
                    break;
                default:
                    Console.WriteLine("It's a draw!");
                    break;
            }
        }
    }

}
