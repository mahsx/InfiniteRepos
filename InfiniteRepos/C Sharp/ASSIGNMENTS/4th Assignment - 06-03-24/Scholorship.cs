using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment4
{
    class Scholarship
    {
        static void Main()
        {
            Console.Write("Enter the marks: ");
            int marks = int.Parse(Console.ReadLine());
            Console.Write("Enter the Fees: ");
            int fees = int.Parse(Console.ReadLine());
            Scholarship sc = new Scholarship();
            int scholarship = sc.merit(marks, fees);
            Console.WriteLine($"You will get your scholarship :{scholarship}");
            Console.ReadKey();

        }
        public int merit(int marks, int fees)
        {
            if (marks >= 70 && marks <= 80)
            {
                fees = (fees * 20) / 100;

            }
            else if (marks > 80 && marks <= 90)
            {
                fees = (fees * 30) / 100;
            }
            else if (marks > 90)
            {
                fees = (fees * 90) / 100;

            }
            return fees;


        }
    }
}
