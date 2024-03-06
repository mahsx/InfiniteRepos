using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            // First Question
            Undergraduate ug = new Undergraduate();  // creating Undergraduate object..
            ug.StudentId = 1;
            ug.Name = "Avinash Singh";
            ug.grade = 56;
            Console.WriteLine($"Undergraduate Passed-> { ug.Ispassed(ug.grade)}");

            Graduate gg = new Graduate();         // creating Graduate object..

            gg.StudentId = 2;
            gg.Name = "Avi";
            gg.grade = 89;
            Console.WriteLine($"Graduate Passed->  {gg.Ispassed(gg.grade)}");
        }
    }
}