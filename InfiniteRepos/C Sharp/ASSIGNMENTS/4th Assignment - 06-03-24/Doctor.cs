using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment4
{
    class Doctor
    {
        private int regnNo;
        private string name;
        private double feescharged;


        public int RegNo { get; set; }
        public string Name { get; set; }
        public double Feescharged { get; set; }

        // Display doctor information
        public void DisplayInfo()
        {
            Console.WriteLine($"Registration Number: {RegNo}");
            Console.WriteLine($"Doctor Name: {Name}");
            Console.WriteLine($"Fees Charged: {Feescharged}");
        }
    }
    class DoctorSolutions
    {
        static void Main()
        {
            Doctor d = new Doctor();
            Console.Write("Enter the RegNo.: ");
            d.RegNo = int.Parse(Console.ReadLine());
            Console.Write("Enter the Name: ");
            d.Name = Console.ReadLine();
            Console.Write("Enter the Fees Charged: ");
            d.Feescharged = Convert.ToSingle(Console.ReadLine());

            d.DisplayInfo();
            Console.ReadKey();
        }
    }
}

