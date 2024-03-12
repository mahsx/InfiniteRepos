using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student
{
    using System;

    // Define the IStudent interface
    interface IStudent
    {
        int StudentId { get; set; }
        string Name { get; set; }
        void ShowDetails();
    }

    // Define the Dayscholar class implementing IStudent
    class Dayscholar : IStudent
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public string TransportMode { get; set; }

        public Dayscholar(int studentId, string name, string transportMode)
        {
            StudentId = studentId;
            Name = name;
            TransportMode = transportMode;
        }

        public void ShowDetails()
        {
            Console.WriteLine($"Dayscholar - Student ID: {StudentId}, Name: {Name}, Transport Mode: {TransportMode}");
        }
    }

    // Define the Resident class implementing IStudent
    class Resident : IStudent
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public string HostelName { get; set; }

        public Resident(int studentId, string name, string hostelName)
        {
            StudentId = studentId;
            Name = name;
            HostelName = hostelName;
        }

        public void ShowDetails()
        {
            Console.WriteLine($"Resident - Student ID: {StudentId}, Name: {Name}, Hostel Name: {HostelName}");
        }
    }

    class StudentDetails
    {
        static void Main()
        {
            // Create instances of Dayscholar and Resident
            IStudent dayscholar = new Dayscholar(studentId: 101, name: "Mahesh", transportMode: "Bike");
            IStudent resident = new Resident(studentId: 102, name: "Sekhar", hostelName: "Hostel A");

            // Display details
            dayscholar.ShowDetails();
            resident.ShowDetails();

            Console.ReadKey();
        }
    }

}
