using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1
{
    class Program
    {
        static void Main(string[] args)
        {
            
            displayMarks();
            Console.Read();
            
        }
            static void equal()
            {
                Console.WriteLine("Input 1st number: ");
                int num1 = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Input 2nd number: ");
                int num2 = Convert.ToInt32(Console.ReadLine());
                if (num1 == num2)
                {
                    Console.WriteLine($"{num1} and {num2} are equal");
                }
                else
                {
                    Console.WriteLine($"{num1} and {num2} are not equal");
                }
            }

            static void positive()
            {
                Console.WriteLine("Enter the number :");
                int a = Convert.ToInt32(Console.ReadLine());
                if (a > 0)
                {
                    Console.WriteLine($"{a} is positive number");
                }
                else
                {
                    Console.WriteLine($"{a} is negative number");
                }
            }
            
            static void operations()
            {
                char operation;

                Console.WriteLine("Enter the number :");
                int b = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter operation ");
                operation = Convert.ToChar(Console.ReadLine());
                Console.WriteLine("Enter the number :");
                int c = Convert.ToInt32(Console.ReadLine());
                switch(operation)
                {
                    case '+':
                    Console.WriteLine($"Addition of numbers {b} and {c} are :{b + c}");
                    break;
                    case '-':
                    Console.WriteLine($"Substraction of numbers {b} and {c} are :{b - c}");
                    break;
                    case '*':
                    Console.WriteLine($"Multiplication of numbers {b} and {c} are :{b * c}");
                    break;
                    case '/':
                    Console.WriteLine($"Division of numbers {b} and {c} are :{b / c}");
                    break;
                    default:
                    Console.WriteLine("Not Possible");
                    break;

                 }
            }
            static void table()
            {
                Console.Write("Enter the number: ");
                int d = Convert.ToInt32(Console.ReadLine());

                for (int i = 0; i <= 10; i++)
                {
                    Console.WriteLine($"{d} * {i} = {d * i}");
                }
            }
           static void sum_triple()
           {
                Console.WriteLine("Enter the first integer:");
                int e = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter the second integer:");
                int f = Convert.ToInt32(Console.ReadLine());

                int sum = e + f;

                if (e == f)
                {
                    sum *= 3;
                }
                Console.WriteLine($"The sum is: {sum}");
           }
            
           static void day()
           {
                Console.WriteLine("Enter the day number :");
                int g = Convert.ToInt32(Console.ReadLine());
                switch (g)
                {
                    case 1:
                        Console.WriteLine("Monday");
                        break;
                    case 2:
                        Console.WriteLine("Tuesday");
                        break;
                    case 3:
                        Console.WriteLine("Wednesday");
                        break;
                    case 4:
                        Console.WriteLine("Thursday");
                        break;
                    case 5:
                        Console.WriteLine("Friday");
                        break;
                    case 6:
                        Console.WriteLine("Saturday");
                        break;
                    case 7:
                        Console.WriteLine("Sunday");
                        break;
                    default:
                        Console.WriteLine("Not possible");
                        break;
                }
                     
           }
           static void array1()
                {
                Console.WriteLine("Enter Array LENGTH :");
                int len = Convert.ToInt32(Console.ReadLine());
                int[] Array = new int[len];
                Console.Write("Enter value for element: ");
                for (int h = 0; h < Array.Length; h++)
                {
                    Array[h] = Convert.ToInt32(Console.ReadLine());
                }

                // Calculate average value
                int sum = 0;
                foreach (int value in Array)
                {
                    sum += value;
                }
                int average = sum / len;

                // Find minimum and maximum values
                int min = Array[0];
                int max = Array[0];
                foreach (int value in Array)
                {
                    if (value < min)
                        min = value;
                    if (value > max)
                        max = value;
                }

                // Print results
                Console.WriteLine($"Average value: {average}");
                Console.WriteLine($"Minimum value: {min}");
                Console.WriteLine($"Maximum value: {max}");
           }

        static void displayMarks()
        {

            int[] marks = new int[10];
            int len = marks.Length;

            Console.WriteLine("Enter the elements of the array:");
            for (int i = 0; i < len; ++i)
            {
                marks[i] = int.Parse(Console.ReadLine());
            }
            int avg, total = 0;
            int min = marks[0];
            int max = marks[0];
            for (int i = 0; i < len; ++i)
            {
                
                if (max < marks[i])
                {
                    max = marks[i];
                }
                if (min > marks[i])
                {
                    min = marks[i];
                }
                total += marks[i];
            }
            

            avg = total / len;
            Console.WriteLine($"Total value: {total}");
            Console.WriteLine($"Average value: {avg}");
            Console.WriteLine($"Minimum value: {min}");
            Console.WriteLine($"Maximum value: {max}");
            Console.WriteLine("Marks in Ascending Order:");
            for (int i = 0; i < len; ++i)
            {
                Console.WriteLine(marks[i]);
            }
            Console.WriteLine("Marks in Descending Order:");
            for (int i = len - 1; i >= 0; --i)
            {
                Console.WriteLine(marks[i]);
            }
        }

        static void copyArray()
        {
            Console.Write("Enter the size of the array: ");
            int len = int.Parse(Console.ReadLine());

            int[] a = new int[len];

            Console.WriteLine("Enter the elements of the array A:");
            for (int i = 0; i < len; ++i)
            {
                a[i] = int.Parse(Console.ReadLine());
            }

            int[] b = new int[len];

            for (int i = 0; i < len; ++i)
            {
                b[i] = a[i];
            }

            Console.WriteLine("elements in the array B:");
            for (int i = 0; i < len; ++i)
            {
                Console.Write(b[i] + " ");
            }
            Console.WriteLine();
        }
        static void length_of_string()
        {
            Console.Write("Enter the string: ");
            string s = Console.ReadLine();
            Console.WriteLine($"Length of String is: {s.Length}");
        }
        static void reverse_of_string()
        {
            Console.Write("Enter the string: ");
            String s = Console.ReadLine();
            String st = "";
            for (int i = s.Length - 1; i >= 0; i--)
            {
                st += s[i];
            }
            Console.WriteLine($"Reverse String is: {st}");
        }
        static void compare_of_string()
        {
            Console.Write("Enter 1st the string: ");
            string s1 = Console.ReadLine();
            Console.Write("Enter 2nd the string: ");
            string s2 = Console.ReadLine();

            if (s1.Equals(s2))
            {
                Console.WriteLine("String 1 and String 2 are equals");
            }
            else
            {
                Console.WriteLine("Not equal");
            }
        }
    }   
}
