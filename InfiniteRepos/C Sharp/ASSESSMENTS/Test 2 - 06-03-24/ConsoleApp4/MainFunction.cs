using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {

            // Student Question
            Undergraduate ug = new Undergraduate();  // Undergraduate object
            ug.StudentId = 1;
            ug.Name = "Mahesh Sekhar";
            ug.grade = 63;
            Console.WriteLine($"Undergraduate Passed-> { ug.Ispassed(ug.grade)}");

            Graduate gg = new Graduate();         // Graduate object

            gg.StudentId = 3;
            gg.Name = "Sahu";
            gg.grade = 94;
            Console.WriteLine($"Graduate Passed->  {gg.Ispassed(gg.grade)}");

            Console.ReadLine();
        }
    }
}