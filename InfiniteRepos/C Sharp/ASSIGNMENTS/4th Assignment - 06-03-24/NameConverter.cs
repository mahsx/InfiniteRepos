using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment4
{
    class NameConverter
    {
        public static void Main()
        {
            // Example usage
            Console.WriteLine("Enter your first name:");
            string firstName = Console.ReadLine();

            Console.WriteLine("Enter your last name:");
            string lastName = Console.ReadLine();

            // Call the Display method
            Display(firstName, lastName);

        }
        static void Display(string firstName, string lastName)
        {
            // Convert names to uppercase
            string upperFirstName = firstName.ToUpper();
            string upperLastName = lastName.ToUpper();

            // Display the names
            Console.WriteLine(upperFirstName);
            Console.WriteLine(upperLastName);
            Console.ReadLine();
        }
    }

}
