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
            Console.WriteLine("Enter Train ID:");
            int trainId = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Train Name:");
            string trainName = Console.ReadLine();

            Console.WriteLine("Enter Total Berths (1st Class):");
            int firstClassBerths = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Total Berths (2nd Class):");
            int secondClassBerths = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Total Berths (Sleeper):");
            int sleeperBerths = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Source:");
            string source = Console.ReadLine();

            Console.WriteLine("Enter Destination:");
            string destination = Console.ReadLine();

            using (SqlCommand command = new SqlCommand("INSERT INTO Trains (TrainId, TrainName, FirstClassBerths, SecondClassBerths, SleeperBerths, Source, Destination) " +
                                                    "VALUES (@TrainId, @TrainName, @FirstClassBerths, @SecondClassBerths, @SleeperBerths, @Source, @Destination)", connection))
            {
                command.Parameters.AddWithValue("@TrainId", trainId);
                command.Parameters.AddWithValue("@TrainName", trainName);
                command.Parameters.AddWithValue("@FirstClassBerths", firstClassBerths);
                command.Parameters.AddWithValue("@SecondClassBerths", secondClassBerths);
                command.Parameters.AddWithValue("@SleeperBerths", sleeperBerths);
                command.Parameters.AddWithValue("@Source", source);
                command.Parameters.AddWithValue("@Destination", destination);
                command.ExecuteNonQuery();
                Console.WriteLine("Train added successfully.");
            }
        }

        public static void ModifyTrain()
        {
            Console.WriteLine("Enter Train ID to Modify:");
            int trainId = int.Parse(Console.ReadLine());

            // Check if the train exists
            string trainName = GetTrainName(trainId);
            if (trainName == null)
            {
                Console.WriteLine("Train does not exist.");
                return;
            }

            Console.WriteLine("Enter New Total Berths (1st Class):");
            int newFirstClassBerths = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter New Total Berths (2nd Class):");
            int newSecondClassBerths = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter New Total Berths (Sleeper):");
            int newSleeperBerths = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter New Source:");
            string newSource = Console.ReadLine();

            Console.WriteLine("Enter New Destination:");
            string newDestination = Console.ReadLine();

            using (SqlCommand command = new SqlCommand("UPDATE Trains SET FirstClassBerths = @NewFirstClassBerths, SecondClassBerths = @NewSecondClassBerths, " +
                                                        "SleeperBerths = @NewSleeperBerths, Source = @NewSource, Destination = @NewDestination WHERE TrainId = @TrainId", connection))
            {
                command.Parameters.AddWithValue("@TrainId", trainId);
                command.Parameters.AddWithValue("@NewFirstClassBerths", newFirstClassBerths);
                command.Parameters.AddWithValue("@NewSecondClassBerths", newSecondClassBerths);
                command.Parameters.AddWithValue("@NewSleeperBerths", newSleeperBerths);
                command.Parameters.AddWithValue("@NewSource", newSource);
                command.Parameters.AddWithValue("@NewDestination", newDestination);
                command.ExecuteNonQuery();
                Console.WriteLine("Train modified successfully.");
            }
        }

        public static void DeleteTrain()
        {
            Console.WriteLine("Enter Train ID to Delete:");
            int trainId = int.Parse(Console.ReadLine());

            // Check if the train exists
            string trainName = GetTrainName(trainId);
            if (trainName == null)
            {
                Console.WriteLine("Train does not exist.");
                return;
            }

            using (SqlCommand command = new SqlCommand("DELETE FROM Trains WHERE TrainId = @TrainId", connection))
            {
                command.Parameters.AddWithValue("@TrainId", trainId);
                command.ExecuteNonQuery();
                Console.WriteLine("Train deleted successfully.");
            }
        }

        private static string GetTrainName(int trainId)
        {
            string trainName = null;
            using (SqlCommand command = new SqlCommand("SELECT TrainName FROM Trains WHERE TrainId = @TrainId", connection))
            {
                command.Parameters.AddWithValue("@TrainId", trainId);
                object result = command.ExecuteScalar();
                if (result != null)
                {
                    trainName = result.ToString();
                }
            }
            return trainName;
        }
    }

    class User
    {
        private static SqlConnection connection = Program.getConnection();

        public static void BookTicket()
        {
            Console.WriteLine("Enter Train ID to Book Ticket:");
            int trainId = int.Parse(Console.ReadLine());

            Console.WriteLine("Select Class (1st/2nd/Sleeper):");
            string selectedClass = Console.ReadLine();

            // Check if the train exists
            string trainName = GetTrainName(trainId);
            if (trainName == null)
            {
                Console.WriteLine("Train does not exist.");
                return;
            }

            // Check available berths in the selected class
            int availableBerths = GetAvailableBerths(trainId, selectedClass);
            if (availableBerths <= 0)
            {
                Console.WriteLine($"No available berths for {selectedClass} class on this train.");
                return;
            }

            Console.WriteLine("Enter Number of Tickets to Book:");
            int ticketsToBook = int.Parse(Console.ReadLine());

            if (ticketsToBook > availableBerths)
            {
                Console.WriteLine($"Insufficient available berths for {selectedClass} class. Available berths: {availableBerths}");
                return;
            }

            // Update available berths in the selected class
            UpdateAvailableBerths(trainId, selectedClass, availableBerths - ticketsToBook);

            Console.WriteLine($"Tickets booked successfully for {ticketsToBook} passengers in {selectedClass} class.");
        }

        public static void CancelTicket()
        {
            Console.WriteLine("Enter Train ID to Cancel Ticket:");
            int trainId = int.Parse(Console.ReadLine());

            Console.WriteLine("Select Class (1st/2nd/Sleeper):");
            string selectedClass = Console.ReadLine();

            // Check if the train exists
            string trainName = GetTrainName(trainId);
            if (trainName == null)
            {
                Console.WriteLine("Train does not exist.");
                return;
            }

            Console.WriteLine("Enter Number of Tickets to Cancel:");
            int ticketsToCancel = int.Parse(Console.ReadLine());

            // Check if tickets can be canceled
            if (ticketsToCancel <= 0)
            {
                Console.WriteLine("Invalid number of tickets to cancel.");
                return;
            }

            // Update available berths in the selected class
            int availableBerths = GetAvailableBerths(trainId, selectedClass);
            UpdateAvailableBerths(trainId, selectedClass, availableBerths + ticketsToCancel);

            Console.WriteLine($"Tickets canceled successfully for {ticketsToCancel} passengers in {selectedClass} class.");
        }

        public static void ShowAvailableTrains()
        {

            using (SqlCommand command = new SqlCommand("SELECT TrainName,TrainId,Source,Destination, FirstClassBerths, SecondClassBerths, SleeperBerths FROM Trains", connection))
            {
                SqlDataReader reader = command.ExecuteReader();

                Console.WriteLine($"Available Trains:");
                while (reader.Read())
                {
                    Console.WriteLine($"Train Name: {reader["TrainName"]}");
                    Console.WriteLine($"Train ID: {reader["TrainId"]}");
                    Console.WriteLine($"Route: {reader["Source"]} to {reader["Destination"]}");
                    Console.WriteLine($"1st Class Berths: {reader["FirstClassBerths"]}");
                    Console.WriteLine($"2nd Class Berths: {reader["SecondClassBerths"]}");
                    Console.WriteLine($"Sleeper Berths: {reader["SleeperBerths"]}");
                    Console.WriteLine("---------------------------------------------");
                }
            }
        } // completed this

        private static string GetTrainName(int trainId)
        {
            string trainName = null;
            using (SqlCommand command = new SqlCommand("SELECT TrainName FROM Trains WHERE TrainId = @TrainId", connection))
            {
                command.Parameters.AddWithValue("@TrainId", trainId);
                object result = command.ExecuteScalar();
                if (result != null)
                {
                    trainName = result.ToString();
                }
            }
            return trainName;
        }

        private static int GetAvailableBerths(int trainId, string selectedClass)
        {
            int availableBerths = -1;
            string column = "";
            switch (selectedClass.ToLower())
            {
                case "1st":
                case "first":
                case "1st class":
                    column = "FirstClassBerths";
                    break;
                case "2nd":
                case "second":
                case "2nd class":
                    column = "SecondClassBerths";
                    break;
                case "sleeper":
                    column = "SleeperBerths";
                    break;
                default:
                    Console.WriteLine("Invalid class selection.");
                    return availableBerths;
            }

            using (SqlCommand command = new SqlCommand($"SELECT {column} FROM Trains WHERE TrainId = @TrainId", connection))
            {
                command.Parameters.AddWithValue("@TrainId", trainId);
                object result = command.ExecuteScalar();
                if (result != null)
                {
                    availableBerths = Convert.ToInt32(result);
                }
            }
            return availableBerths;
        }

        private static void UpdateAvailableBerths(int trainId, string selectedClass, int newAvailableBerths)
        {
            string column = "";
            switch (selectedClass.ToLower())
            {
                case "1st":
                case "first":
                case "1st class":
                    column = "FirstClassBerths";
                    break;
                case "2nd":
                case "second":
                case "2nd class":
                    column = "SecondClassBerths";
                    break;
                case "sleeper":
                    column = "SleeperBerths";
                    break;
                default:
                    Console.WriteLine("Invalid class selection.");
                    return;
            }

            using (SqlCommand command = new SqlCommand($"UPDATE Trains SET {column} = @AvailableBerths WHERE TrainId = @TrainId", connection))
            {
                command.Parameters.AddWithValue("@TrainId", trainId);
                command.Parameters.AddWithValue("@AvailableBerths", newAvailableBerths);
                command.ExecuteNonQuery();
            }
        }
    }
}
