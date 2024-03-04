using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{   class Student
    {
        private string rollno;
        private string name;
        private string class_name;
        private string semester;
        private string branch;
        private int[] marks = new int[5];

        public Student(string rollno, string name, string class_name, string semester, string branch)
        {
            this.rollno = rollno;
            this.name = name;
            this.class_name = class_name;
            this.semester = semester;
            this.branch = branch;
        }

        public void GetMarks()
        {
            Console.WriteLine($"Enter marks for {name} (out of 100) for 5 subjects:");
            for (int i = 0; i < 5; i++)
            {
                Console.Write($"Subject {i + 1}: ");
                marks[i] = Convert.ToInt32(Console.ReadLine());
            }
        }

        public double CalculateAverage()
        {
            int totalMarks = 0;
            foreach (int mark in marks)
            {
                totalMarks += mark;
            }
            return (double)totalMarks / 5;
        }

        public void DisplayResult()
        {
            double averageMarks = CalculateAverage();

            if (marks.Any(mark => mark < 35))
            {
                Console.WriteLine("Result: Failed (Marks of at least one subject are less than 35)");
            }
            else if (averageMarks < 50)
            {
                Console.WriteLine("Result: Failed (Average marks are less than 50)");
            }
            else
            {
                Console.WriteLine("Result: Passed");
            }
        }

        public void DisplayData()
        {
            Console.WriteLine($"Roll No: {rollno}");
            Console.WriteLine($"Name: {name}");
            Console.WriteLine($"Class: {class_name}");
            Console.WriteLine($"Semester: {semester}");
            Console.WriteLine($"Branch: {branch}");
            Console.WriteLine($"Marks: [{string.Join(", ", marks)}]");
        }

        public static void Main()
        {
            Console.Write("Enter Roll No: ");
            string rollno = Console.ReadLine();

            Console.Write("Enter Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Class: ");
            string class_name = Console.ReadLine();

            Console.Write("Enter Semester: ");
            string semester = Console.ReadLine();

            Console.Write("Enter Branch: ");
            string branch = Console.ReadLine();

            Student student1 = new Student(rollno, name, class_name, semester, branch);
            student1.GetMarks();
            student1.DisplayResult();
            student1.DisplayData();
        }
    }
}
