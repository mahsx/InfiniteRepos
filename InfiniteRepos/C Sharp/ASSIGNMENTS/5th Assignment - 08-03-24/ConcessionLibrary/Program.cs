using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConcessionLibrary
{
    class Program
    {
        static void Main(string[] args)
        {


            TicketConcession passenger1 = new TicketConcession("Mahesh", 23);
            TicketConcession passenger2 = new TicketConcession("BLA BLA", 65);
            TicketConcession passenger3 = new TicketConcession("SEKHAR", 30);

            passenger1.CalculateConcession();
            passenger2.CalculateConcession();
            passenger3.CalculateConcession();
            Console.ReadKey();
        }
    }
}

