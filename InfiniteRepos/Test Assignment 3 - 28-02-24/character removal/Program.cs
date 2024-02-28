using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace character_removal
{
    class Program
    {
        static void Main(string[] args)
        {
            character();
            exchange();
            largest();
            Console.Read();
        }

        static void character()
        {
            Console.Write("Enter a string: ");
            string input = Console.ReadLine();

            Console.Write("Enter the position to remove (starts from 0): ");
            int position = int.Parse(Console.ReadLine());

            if (position >= 0 && position < input.Length)
            { 
                string result = input.Remove(position, 1);
                Console.WriteLine("Output: " + result);
            }
            else
            {
                Console.WriteLine("Invalid position. Please enter a valid position as per string length.");
            }
        }

        static void exchange()
        {
            Console.Write("Enter a string: ");
            string enter = Console.ReadLine();

            if (enter.Length > 1)
            {
                char firstChar = enter[0];
                char lastChar = enter[enter.Length - 1];

                string result = $"{lastChar}{enter.Substring(1, enter.Length - 2)}{firstChar}";
                Console.WriteLine("Output: " + result);
            }
            else
            {
                Console.WriteLine(enter);
            }
        }

        static void largest()
        {
            int first, second, third;

            Console.WriteLine("Enter the first number: ");
            first = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the second number: ");
            second = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the third number: ");
            third = int.Parse(Console.ReadLine());

            if (first > second)
            {
                if (first > third)
                {
                    Console.WriteLine("Largest number: " + first);
                }
                else
                {
                    Console.WriteLine("Largest number: " + third);
                }
            }
            else
            {
                if (second > third)
                {
                    Console.WriteLine("Largest number: " + second);
                }
                else
                {
                    Console.WriteLine("Largest number: " + third);
                }
            }
        }
    }
}
