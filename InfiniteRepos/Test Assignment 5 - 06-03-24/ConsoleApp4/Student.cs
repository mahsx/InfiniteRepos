using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    abstract class Student
    {
        public string Name;
        public int StudentId;
        public int grade;
        abstract public bool Ispassed(int grade); // Abstract method

    }
    class Undergraduate : Student
    {
        public override bool Ispassed(int grade)
        {
            if (grade > 70)
                return true;
            else
                return false;
        }
    }
    class Graduate : Student
    {
        public override bool Ispassed(int grade)
        {
            if (grade > 80)
                return true;
            else
                return false;

        }

    }
}