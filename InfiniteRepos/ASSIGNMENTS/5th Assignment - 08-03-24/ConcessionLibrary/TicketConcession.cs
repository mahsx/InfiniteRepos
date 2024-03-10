using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConcessionLibrary
{
    public class TicketConcession
    {
        private const double TotalFare = 500.0; // Fixed total fare amount

        public string Name { get; }
        public int Age { get; }

        public TicketConcession(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public void CalculateConcession()
        {
            if (Age <= 5)
            {
                Console.WriteLine($"Little Champs - Free Ticket for {Name}, Age: {Age}");
            }
            else if (Age > 60)
            {
                double concessionAmount = 0.3 * TotalFare;
                double seniorCitizenFare = TotalFare - concessionAmount;
                Console.WriteLine($"Senior Citizen - Fare for {Name}, Age: {Age}: ${seniorCitizenFare:F2}");
            }
            else
            {
                Console.WriteLine($"Ticket Booked - Fare for {Name}, Age: {Age}: ${TotalFare:F2}");
            }
        }

        // Example usage:
        static void Main()
        {
            TicketConcession passenger1 = new TicketConcession("Mahesh", 3);
            TicketConcession passenger2 = new TicketConcession("BLA BLA", 65);
            TicketConcession passenger3 = new TicketConcession("SEKHAR", 30);

            passenger1.CalculateConcession();
            passenger2.CalculateConcession();
            passenger3.CalculateConcession();
            Console.ReadKey();
        }
    }
}

