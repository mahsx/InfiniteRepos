using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment4
{
    class CharacterOccur
    {
        static void Main()
        {
            Console.Write("Enter the String: ");
            string s = Console.ReadLine();
            Console.Write("Write the character for count: ");
            char ch = Convert.ToChar(Console.ReadLine());
            charOccurrence(ch, s);
            Console.ReadKey();

        }
        static void charOccurrence(char ch, string s)
        {
            int count = 0;

            foreach (char c in s)
            {
                if (c == ch)
                {
                    count++;
                }
            }
            Console.WriteLine($"{ch} appears in {s}: {count} times");
        }
    }
}