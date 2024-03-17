using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Box
{
    class Box
    {
        public double Length { get; set; }
        public double Breadth { get; set; }

        // Constructor to initialize Length and Breadth
        public Box(double length, double breadth)
        {
            Length = length;
            Breadth = breadth;
        }

        // Method to add two Box objects and store in a third Box
        public Box AddBoxes(Box otherBox)
        {
            double sumLength = Length + otherBox.Length;
            double sumBreadth = Breadth + otherBox.Breadth;
            return new Box(sumLength, sumBreadth);
        }
    }

    class Test
    {
        static void Main()
        {
            //// Create two Box objects
            //Box box1 = new Box(5, 3);
            //Box box2 = new Box(2, 4);

            //// Add the boxes and store the result in a third Box
            //Box resultBox = box1.AddBoxes(box2);

            //// Display the details of the boxes
            //Console.WriteLine($"Box 1: Length = {box1.Length}, Breadth = {box1.Breadth}");
            //Console.WriteLine($"Box 2: Length = {box2.Length}, Breadth = {box2.Breadth}");
            //Console.WriteLine($"Sum of Box 1 and Box 2: Length = {resultBox.Length}, Breadth = {resultBox.Breadth}");

            Console.Write("Enter the length of Box 1: ");
            double length1 = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter the breadth of Box 1: ");
            double breadth1 = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter the length of Box 2: ");
            double length2 = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter the breadth of Box 2: ");
            double breadth2 = Convert.ToDouble(Console.ReadLine());

            // Create Box objects
            Box box1 = new Box(length1, breadth1);
            Box box2 = new Box(length2, breadth2);

            // Add the boxes and store the result in a third Box
            Box resultBox = box1.AddBoxes(box2);

            // Display the details of the boxes
            Console.WriteLine($"Box 1: Length = {box1.Length}, Breadth = {box1.Breadth}");
            Console.WriteLine($"Box 2: Length = {box2.Length}, Breadth = {box2.Breadth}");
            Console.WriteLine($"Sum of Box 1 and Box 2: Length = {resultBox.Length}, Breadth = {resultBox.Breadth}");
            Console.ReadKey();
        }
    }

}
