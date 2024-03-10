using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WordFilter
{
    class Program
    {
        static void Main()
        {
            Console.Write("Enter a comma-separated list of words: ");
            string input = Console.ReadLine();

            string[] words = input.Split(',').Select(word => word.Trim()).ToArray();
           

            foreach (string word in words)
            {
                if (IsWordValid(word))
                {
                    Console.WriteLine(word);
                    Console.ReadKey();
                }
            }
        }

        static bool IsWordValid(string word)
        {
            return word.StartsWith("a", StringComparison.OrdinalIgnoreCase) &&
                   word.EndsWith("m", StringComparison.OrdinalIgnoreCase);
        }
    }
}

