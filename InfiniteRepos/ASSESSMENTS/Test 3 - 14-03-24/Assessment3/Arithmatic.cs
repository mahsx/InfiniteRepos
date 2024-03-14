using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Arithmatic
{
        // Declared a delegate
        delegate double ArithmeticDelegate(double x, double y);

        class ArithmeticOperations
        {
            static void Menu()
            {
                Console.WriteLine("Select an arithmetic operation:");
                Console.WriteLine("1) Addition");
                Console.WriteLine("2) Subtraction");
                Console.WriteLine("3) Multiplication");
                Console.WriteLine("4) Quit");
            }

            static double Add(double a, double b)
            {
                return a + b;
            }

            static double Subtract(double a, double b)
            {
                return a - b;
            }

            static double Multiply(double a, double b)
            {
                return a * b;
            }

            static void Main(string[] args)
            {
                int operation;
                ArithmeticDelegate arithmetic;
                double x, y;

                do
                {
                    Console.WriteLine("Enter two numbers separated by Enter:");
                    x = double.Parse(Console.ReadLine());
                    y = double.Parse(Console.ReadLine());

                    Console.Clear();
                    Menu();
                    operation = int.Parse(Console.ReadLine());

                    switch (operation)
                    {
                        case 1:
                            arithmetic = Add;
                            break;
                        case 2:
                            arithmetic = Subtract;
                            break;
                        case 3:
                            arithmetic = Multiply;
                            break;
                        default:
                            Console.WriteLine("Exiting program");
                            return;
                    }

                    Console.Clear();
                    double result = arithmetic(x, y);
                    Console.WriteLine($"Result: {result}");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey(true);
                    Console.Clear();
                    Console.ReadKey();
                } while (operation != 4);
            }
        }
    }