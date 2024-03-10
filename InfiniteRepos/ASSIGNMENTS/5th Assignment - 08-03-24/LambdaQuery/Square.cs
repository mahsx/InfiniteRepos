using System;
using System.Collections.Generic;
using System.Linq;

namespace SquareCalculator
{
    class Program
    {
        static void Main()
        {
            Console.Write("Enter a list of comma-separated numbers: ");
            string input = Console.ReadLine();

            List<int> numbers = ParseInput(input);
            List<int> squares = CalculateSquares(numbers);

            int productOfSquares = CalculateProductOfSquares(squares);

            Console.WriteLine($"Product of squares greater than 20: {productOfSquares}");
            Console.ReadKey();
        }

        static List<int> ParseInput(string input)
        {
            return input.Split(',')
                        .Select(s => int.TryParse(s.Trim(), out int num) ? num : 0)
                        .ToList();
        }

        static List<int> CalculateSquares(List<int> numbers)
        {
            return numbers.Select(x => x * x)
                          .Where(square => square > 20)
                          .ToList();
        }

        static int CalculateProductOfSquares(List<int> squares)
        {
            int result = 1;
            foreach (int square in squares)
            {
                result *= square;
            }
            return result;
        }
    }
}
