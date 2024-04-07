using System;
using System.Data.SqlClient;

namespace RailwayTicketBookingSystem
{
    class Program
    {
        private static SqlConnection connection = getConnection();

        public static SqlConnection getConnection()
        {
            SqlConnection con = new SqlConnection("Server=ICS-LT-4XYM473\\SQLEXPRESS;Database=Trains;Integrated Security=True;");
            con.Open();
            return con;
        }

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Welcome to Railway Ticket Booking System");
                Console.WriteLine("1. Admin");
                Console.WriteLine("2. User");
                Console.WriteLine("3. Exit");
                Console.WriteLine("Enter your choice:");

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        AdminActions();
                        break;
                    case 2:
                        UserActions();
                        break;
                    case 3:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        static void AdminActions()
        {
            Console.WriteLine("Admin Actions:");
            Console.WriteLine("1. Add Train");
            Console.WriteLine("2. Modify Train");
            Console.WriteLine("3. Delete Train");
            Console.WriteLine("Enter your choice:");

            int adminChoice = int.Parse(Console.ReadLine());

            switch (adminChoice)
            {
                case 1:
                    Admin.AddTrain();
                    break;
                case 2:
                    Admin.ModifyTrain();
                    break;
                case 3:
                    Admin.DeleteTrain();
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }

        static void UserActions()
        {
            Console.WriteLine("User Actions:");
            Console.WriteLine("1. Book Ticket");
            Console.WriteLine("2. Cancel Ticket");
            Console.WriteLine("3. Show Available Trains");
            Console.WriteLine("Enter your choice:");

            int userChoice = int.Parse(Console.ReadLine());

            switch (userChoice)
            {
                case 1:
                    User.BookTicket();
                    break;
                case 2:
                    User.CancelTicket();
                    break;
                case 3:
                    User.ShowAvailableTrains();
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    class Admin
    {
        private static SqlConnection connection = Program.getConnection();

        public static void AddTrain()
        {
            Console.WriteLine("Enter Train Name:");
            string trainName = Console.ReadLine();

            Console.WriteLine("Enter Class (1st/2nd/Sleeper):");
            string trainClass = Console.ReadLine();

            Console.WriteLine("Enter Total Berths:");
            int totalBerths = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Available Berths:");
            int availableBerths = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Source:");
            string source = Console.ReadLine();

            Console.WriteLine("Enter Destination:");
            string destination = Console.ReadLine();

            using (SqlCommand command = new SqlCommand("INSERT INTO Trains (TrainName, Class, TotalBerths, AvailableBerths, Source, Destination) " +
                                                    "VALUES (@TrainName, @Class, @TotalBerths, @AvailableBerths, @Source, @Destination)", connection))
            {
                command.Parameters.AddWithValue("@TrainName", trainName);
                command.Parameters.AddWithValue("@Class", trainClass);
                command.Parameters.AddWithValue("@TotalBerths", totalBerths);
                command.Parameters.AddWithValue("@AvailableBerths", availableBerths);
                command.Parameters.AddWithValue("@Source", source);
                command.Parameters.AddWithValue("@Destination", destination);
                command.ExecuteNonQuery();
                Console.WriteLine("Train added successfully.");
            }
        }

        public static void ModifyTrain()
        {
            Console.WriteLine("Enter Train Name to Modify:");
            string trainName = Console.ReadLine();

            // Check if the train exists
            int trainId = GetTrainId(trainName);
            if (trainId == -1)
            {
                Console.WriteLine("Train does not exist.");
                return;
            }

            Console.WriteLine("Enter New Class (1st/2nd/Sleeper):");
            string trainClass = Console.ReadLine();

            Console.WriteLine("Enter New Total Berths:");
            int totalBerths = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter New Available Berths:");
            int availableBerths = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter New Source:");
            string source = Console.ReadLine();

            Console.WriteLine("Enter New Destination:");
            string destination = Console.ReadLine();

            using (SqlCommand command = new SqlCommand("UPDATE Trains SET Class = @Class, TotalBerths = @TotalBerths, AvailableBerths = @AvailableBerths, " +
                                                        "Source = @Source, Destination = @Destination WHERE TrainName = @TrainName", connection))
            {
                command.Parameters.AddWithValue("@TrainName", trainName);
                command.Parameters.AddWithValue("@Class", trainClass);
                command.Parameters.AddWithValue("@TotalBerths", totalBerths);
                command.Parameters.AddWithValue("@AvailableBerths", availableBerths);
                command.Parameters.AddWithValue("@Source", source);
                command.Parameters.AddWithValue("@Destination", destination);
                command.ExecuteNonQuery();
                Console.WriteLine("Train modified successfully.");
            }
        }

        public static void DeleteTrain()
        {
            Console.WriteLine("Enter Train Name to Delete:");
            string trainName = Console.ReadLine();

            // Check if the train exists
            int trainId = GetTrainId(trainName);
            if (trainId == -1)
            {
                Console.WriteLine("Train does not exist.");
                return;
            }

            using (SqlCommand command = new SqlCommand("DELETE FROM Trains WHERE TrainName = @TrainName", connection))
            {
                command.Parameters.AddWithValue("@TrainName", trainName);
                command.ExecuteNonQuery();
                Console.WriteLine("Train deleted successfully.");
            }
        }

        private static int GetTrainId(string trainName)
        {
            int trainId = -1;
            using (SqlCommand command = new SqlCommand("SELECT TrainId FROM Trains WHERE TrainName = @TrainName", connection))
            {
                command.Parameters.AddWithValue("@TrainName", trainName);
                object result = command.ExecuteScalar();
                if (result != null)
                {
                    trainId = Convert.ToInt32(result);
                }
            }
            return trainId;
        }
    }

    class User
    {
        private static SqlConnection connection = Program.getConnection();

        public static void BookTicket()
        {
            // Book ticket functionality
            Console.WriteLine("Book Ticket functionality is not implemented yet.");
        }

        public static void CancelTicket()
        {
            // Cancel ticket functionality
            Console.WriteLine("Cancel Ticket functionality is not implemented yet.");
        }

        public static void ShowAvailableTrains()
        {
            // Show available trains functionality
            using (SqlCommand command = new SqlCommand("SELECT * FROM Trains", connection))
            {
                SqlDataReader reader = command.ExecuteReader();

                Console.WriteLine("Available Trains:");
                Console.WriteLine("Train Name | Class | Total Berths | Available Berths | Source | Destination");
                while (reader.Read())
                {
                    Console.WriteLine($"{reader["TrainName"]} | {reader["Class"]} | {reader["TotalBerths"]} | {reader["AvailableBerths"]} | {reader["Source"]} | {reader["Destination"]}");
                }
            }
        }
    }
}
