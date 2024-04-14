using System;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;
using System.Threading;


namespace RailwayTicketBookingSystem
{
    public class Train
    {
        public int TrainId { get; set; }
        public string Source { get; set; }
        public string Destination { get; set; }
    }

    class Program
    {
        private static string connectionString = "Server=ICS-LT-4XYM473\\SQLEXPRESS;Database=Trains;Integrated Security=True;";
        private static SqlConnection connection = new SqlConnection(connectionString);
        private static int UserId; // This should be set after successful user login
        private static int AdminId;
        private static int MaxTicketsPerBooking = 5;
        private static string AdminEmail = "null"; // Change this to your admin email
        private static string SmtpServer = "smtp.gmail.com"; // Change this to your SMTP server
        private static int SmtpPort = 587; // Change this to your SMTP port
        private static string SmtpUsername = " "; // Change this to your SMTP username
        private static string SmtpPassword = " "; // Change this to your SMTP password

        static Train GetTrainById(int trainId)
        {
            string query = "SELECT TrainId, Source, Destination FROM Trains WHERE TrainId = @TrainId";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@TrainId", trainId);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Train
                        {
                            TrainId = Convert.ToInt32(reader["TrainId"]),
                            Source = reader["Source"].ToString(),
                            Destination = reader["Destination"].ToString()
                        };
                    }
                }
            }
            return null; // Train not found
        }
        static void Main(string[] args)
        {
            Home();
            Console.ReadKey();
        } 

        static void Home()
        {
            try
            {
                connection.Open();
                Console.WriteLine("\n Database connection established. \n ");

                while (true)
                {
                    Console.WriteLine("\t\t\t\t\t Welcome to Railway Ticket Booking System ");
                    Console.WriteLine("\t\t\t\t\t------------------------------------------ \n");
                    Console.WriteLine("1. Admin");
                    Console.WriteLine("2. User");
                    Console.WriteLine("3. Exit \n");
                    Console.Write("Enter your choice: ");


                    int choice;
                    if (!int.TryParse(Console.ReadLine(), out choice))
                    {
                        Console.WriteLine("\n Invalid input. Please enter a number.");
                        continue;
                    }

                    switch (choice)
                    {
                        case 1:
                            
                            for (int i = 2; i > 0; i--)
                            {
                                Console.Clear();
                                Console.WriteLine("Redirecting to Admin LogIn in " + i + " seconds...");
                                Thread.Sleep(1000); // Pause for 1 second
                            }
                            Console.Clear();
                            AdminLogin();
                            break;
                        case 2:
                            for (int i = 2; i > 0; i--)
                            {
                                Console.Clear();
                                Console.WriteLine("Redirecting to User Page in " + i + " seconds...");
                                Thread.Sleep(1000); // Pause for 1 second
                            }
                            Console.Clear();
                            UserActions();
                            break;
                        case 3:
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("\n Invalid choice. Please try again.");
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            finally
            {
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                    Console.WriteLine("Database connection closed. \n");
                }
            }
        } //clear

        static void SendOTPByEmail(string userEmail, string otp)
        {
            try
            {
                using (SmtpClient smtpClient = new SmtpClient(SmtpServer, SmtpPort))
                {
                    smtpClient.UseDefaultCredentials = false;
                    smtpClient.Credentials = new NetworkCredential(SmtpUsername, SmtpPassword);
                    smtpClient.EnableSsl = true;

                    MailMessage mailMessage = new MailMessage(AdminEmail, userEmail);
                    mailMessage.Subject = "OTP for Mahesh's Booking System";
                    mailMessage.Body = $"Your OTP for login is: {otp}";

                    smtpClient.Send(mailMessage);
                    Console.WriteLine("OTP sent successfully to your email.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error sending OTP: {ex.Message}");
            }
        } //clear
    
        static void AdminLogin()
        {
            Console.Clear();
            Console.WriteLine("\t\t\t\t\t WELCOME TO ADMIN LOG-IN");
            Console.WriteLine("\t\t\t\t\t--------------------------- \n\n");

            Console.Write("Enter Admin Username: ");
            string Username = Console.ReadLine();

            Console.Write("Enter Admin Password: ");
            string Password = Console.ReadLine();

            Console.Write("Enter Admin Email: ");
            string AdminEmail = Console.ReadLine();
            Console.Clear();


            string query = "SELECT AdminId FROM Admins WHERE Username = @Username AND Password = @Password and AdminEmail = @AdminEmail";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Username", Username);
                command.Parameters.AddWithValue("@Password", Password);
                command.Parameters.AddWithValue("@AdminEmail", AdminEmail);
                object result = command.ExecuteScalar();
                if (result != null)
                {
                    for (int i = 3; i > 0; i--)
                    {
                        Console.Clear();
                        Console.WriteLine("Redirecting to Admin Action in " + i + " seconds...");
                        Thread.Sleep(1000); // Pause for 1 second
                    }

                    Console.Clear();
                    AdminActions();
                }
                else
                {
                    Console.WriteLine("Invalid admin credentials. Kindly Retry...\n \n");
                    return;
                }
            }
        }  //clear

        static void AdminActions()
        {
            Console.WriteLine("\t\t\t\t\t WELCOME TO ADMIN SECTION");
            Console.WriteLine("\t\t\t\t\t--------------------------- \n\n");
            Console.WriteLine("1. Add Train");
            Console.WriteLine("2. Modify Train");
            Console.WriteLine("3. Delete Train");
            Console.WriteLine("4. Show All Trains");
            Console.WriteLine("5. Logout");
            Console.WriteLine("Enter your choice: \n ");

            int adminChoice;
            if (!int.TryParse(Console.ReadLine(), out adminChoice))
            {
                Console.WriteLine("Invalid input. Please enter a number.");
                return;
            }

            switch (adminChoice)
            {
                case 1:
                    Admin.AddTrain(connection);
                    break;
                case 2:
                    Admin.ModifyTrain(connection);
                    break;
                case 3:
                    Admin.DeleteTrain(connection);
                    break;
                case 4:
                    Admin.ShowAllTrains(connection);
                    break;
                case 5:
                    AdminId = 0; // Logout by resetting AdminId
                    Console.WriteLine("Logged out successfully.");
                    Home(); // Redirect back to Home page
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }  //clear



        static void UserActions()
        {
            Console.Clear();
            Console.WriteLine("\t\t\t\t\t WELCOME TO USER PAGE");
            Console.WriteLine("\t\t\t\t\t----------------------- \n");
            Console.WriteLine("1. Existing User Login");
            Console.WriteLine("2. New User Registration");
            Console.Write("Enter your choice: ");

            int userChoice;
            if (!int.TryParse(Console.ReadLine(), out userChoice))
            {
                
                Console.WriteLine("Invalid input. Please enter a number.\n\n");
            }

            switch (userChoice)
            {
                case 1:
                    UserLogin();
                    break;
                case 2:
                    RegisterUser();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        } //clear

        static void UserLogin()
        {
            Console.Clear();
            Console.WriteLine("\t\t\t\t\t WELCOME TO USER LOG-IN");
            Console.WriteLine("\t\t\t\t\t--------------------------- \n\n");
            Console.Write("Enter Username: ");
            string username = Console.ReadLine();

            Console.Write("Enter Password: ");
            string password = Console.ReadLine();

            string query = "SELECT UserId, Email FROM Users WHERE Username = @Username AND Password = @Password";

            // Use a new connection object within this method scope
            using (SqlConnection loginConnection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, loginConnection))
                {
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Password", password);

                    try
                    {
                        loginConnection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                UserId = Convert.ToInt32(reader["UserId"]);
                                string userEmail = reader["Email"].ToString();
                                Console.WriteLine("Login successful. Wait For OTP Verification");
                                Console.WriteLine($"otp sent to :{userEmail}");
                                string otp = GenerateOTP();
                                // Close DataReader before sending OTP
                                reader.Close();
                                SendOTPByEmail(userEmail, otp);
                                // Redirect to OTP verification
                                VerifyOTP(otp);
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Invalid username or password.");
                                for (int i = 3; i > 0; i--)
                                {
                                    Console.Clear();
                                    Console.WriteLine("Redirecting to User Action in " + i + " seconds...");
                                    Thread.Sleep(1000); // Pause for 1 second
                                }
                                Console.Clear();
                                UserActions(); // Redirect back to user action page
                               
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                    }
                }
            } // Connection is automatically closed checked 1
        } //clear

        static string GenerateOTP()
        {
            Random random = new Random();
            int otpValue = random.Next(100,101);
            return otpValue.ToString();
        }  //clear

        static void VerifyOTP(string otp)
        {
            Console.Write("Enter OTP received on your email: ");
            string userOTP = Console.ReadLine();

            if (userOTP == otp)
            {
                Console.WriteLine("OTP verified successfully");

                for (int i = 2; i > 0; i--)
                {
                    Console.Clear();
                    Console.WriteLine("Redirecting to user section in " + i + " seconds...");
                    Thread.Sleep(1000); // Pause for 1 second
                }
                Console.Clear();
                UserActionsAfterLogin();
            }
            else
            {
                Console.WriteLine("Invalid OTP. Please try again.");
                Console.Clear();
                UserLogin(); // Redirect back to login
            }
        }  //clear

        static void RegisterUser()
        {
            Console.Clear();

            Console.WriteLine("\t\t\t\t\t WELCOME TO USER REGISTRATION");
            Console.WriteLine("\t\t\t\t\t------------------------------- \n\n");

            Console.Write("Enter Username: ");
            string username = Console.ReadLine();

            Console.Write("Enter Password: ");
            string password = Console.ReadLine();

            Console.Write("Enter Your Email: ");
            string Email = Console.ReadLine();

            string query = "INSERT INTO Users (Username, Password, Email) VALUES (@Username, @Password, @Email)";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Username", username);
                command.Parameters.AddWithValue("@Password", password);
                command.Parameters.AddWithValue("@Email", Email);


                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    Console.WriteLine("User registered successfully.");
                    for (int i = 2; i > 0; i--)
                    {
                        Console.Clear();
                        Console.WriteLine("Redirecting to LogIn in " + i + " seconds...");
                        Thread.Sleep(1000); // Pause for 1 second
                    }
                    Console.Clear();
                    UserLogin();
                }
                else
                    Console.WriteLine("Failed to register user.");
            }
        } //clear

        static void UserActionsAfterLogin()
        {
            Console.WriteLine("\nWELCOME TO USER SECTION");
            Console.WriteLine("------------------------ \n");
            Console.WriteLine("1. Book Ticket");
            Console.WriteLine("2. Cancel Ticket");
            Console.WriteLine("3. Show Available Trains");
            Console.WriteLine("4. Logout");
            Console.WriteLine("Enter your choice:");

            int userChoice;
            if (!int.TryParse(Console.ReadLine(), out userChoice))
            {
                Console.WriteLine("Invalid input. Please enter a number.");
                UserActionsAfterLogin(); // Redirect back to actions after login
                return;
            }

            switch (userChoice)
            {
                case 1:
                    UserBooking();
                    break;
                case 2:
                    CancelTicket();
                    break;
                case 3:
                    ShowAvailableTrains();
                    break;
                case 4:
                    UserId = 0; // Logout by resetting UserId
                    Console.WriteLine("Logged out successfully.");
                    UserActions(); // Redirect back to user action page
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    UserActionsAfterLogin(); // Redirect back to actions after login
                    break;
            }
        }
    
        static void CancelTicket()
        {
            if (UserId == 0)
            {
                Console.WriteLine("Please log in to cancel tickets.");
                UserLogin();
            }

            Console.WriteLine("Choose cancellation method:");
            Console.WriteLine("1. Cancel by Booking ID");
            Console.WriteLine("2. Cancel by PNR");
            Console.WriteLine("Enter your choice:");

            int cancelChoice;
            if (!int.TryParse(Console.ReadLine(), out cancelChoice))
            {
                Console.WriteLine("Invalid choice. Please try again.");
                CancelTicket();
                return;
            }

            switch (cancelChoice)
            {
                case 1:
                    Console.WriteLine("Enter Booking ID to Cancel Ticket:");
                    int bookingId;
                    if (!int.TryParse(Console.ReadLine(), out bookingId))
                    {
                        Console.WriteLine("Invalid Booking ID. Please enter a valid number.");
                        UserActionsAfterLogin();
                        return;
                    }

                    // Check if the booking exists
                    if (!CheckBookingExists(bookingId))
                    {
                        Console.WriteLine("Booking does not exist.");
                        UserActionsAfterLogin();
                        return;
                    }

                    CancelTicketByBookingId(bookingId);
                    break;

                case 2:
                    Console.WriteLine("Enter PNR to Cancel Ticket:");
                    int pnr;
                    if (!int.TryParse(Console.ReadLine(), out pnr))
                    {
                        Console.WriteLine("Invalid PNR. Please enter a valid number.");
                        UserActionsAfterLogin();
                        return;
                    }

                    CancelTicketByPNR(pnr);
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    CancelTicket();
                    break;
            }
        }

        static void UpdateAvailableBerthsAfterCancellation(int trainId, string classType, int ticketsCancelled)
        {
            string columnToUpdate = "";

            switch (classType.ToLower())
            {
                case "1st":
                case "first":
                case "1st class":
                    columnToUpdate = "FirstClassBerths";
                    break;
                case "2nd":
                case "second":
                case "2nd class":
                    columnToUpdate = "SecondClassBerths";
                    break;
                case "sleeper":
                    columnToUpdate = "SleeperBerths";
                    break;
                default:
                    Console.WriteLine("Invalid class type.");
                    return;
            }

            string queryUpdateBerths = $"UPDATE Trains SET {columnToUpdate} = {columnToUpdate} + @TicketsCancelled WHERE TrainId = @TrainId";

            using (SqlConnection updateConnection = new SqlConnection(connectionString))
            {
                updateConnection.Open();

                using (SqlCommand updateCommand = new SqlCommand(queryUpdateBerths, updateConnection))
                {
                    updateCommand.Parameters.AddWithValue("@TicketsCancelled", ticketsCancelled);
                    updateCommand.Parameters.AddWithValue("@TrainId", trainId);

                    int updateRows = updateCommand.ExecuteNonQuery();
                    if (updateRows > 0)
                    {
                        Console.WriteLine("Available berths updated after cancellation.");
                    }
                    else
                    {
                        Console.WriteLine("Failed to update available berths after cancellation.");
                    }
                }

                updateConnection.Close();
            }
        }

        static void CancelTicketByPNR(int pnr)
        {
            int trainId = 0;
            string classType = "";

            string queryBookingDetails = "SELECT TrainId, ClassType, COUNT(*) AS TicketsCancelled FROM Bookings WHERE PNR = @PNR AND UserId = @UserId GROUP BY TrainId, ClassType";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(queryBookingDetails, connection))
                {
                    command.Parameters.AddWithValue("@PNR", pnr);
                    command.Parameters.AddWithValue("@UserId", UserId);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            trainId = Convert.ToInt32(reader["TrainId"]);
                            classType = reader["ClassType"].ToString();
                            int ticketsCancelled = Convert.ToInt32(reader["TicketsCancelled"]);
                            UpdateAvailableBerthsAfterCancellation(trainId, classType, ticketsCancelled);
                        }
                    }
                }

                if (trainId == 0)
                {
                    Console.WriteLine("No tickets found for the specified PNR.");
                    UserActionsAfterLogin();
                    return;
                }

                // Cancel the tickets by deleting from the Bookings table
                string queryCancelTickets = "DELETE FROM Bookings WHERE PNR = @PNR AND UserId = @UserId";

                using (SqlCommand cancelCommand = new SqlCommand(queryCancelTickets, connection))
                {
                    cancelCommand.Parameters.AddWithValue("@PNR", pnr);
                    cancelCommand.Parameters.AddWithValue("@UserId", UserId);

                    int rowsAffected = cancelCommand.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("Tickets canceled successfully.");
                        Console.WriteLine("Available berths updated.");
                    }
                    else
                    {
                        Console.WriteLine("No tickets found for the specified PNR.");
                    }
                }

                connection.Close();
            }

            UserActionsAfterLogin(); // Redirect back to actions after cancellation
        }

        static void CancelTicketByBookingId(int bookingId)
        {
            // Retrieve the train ID and number of tickets to cancel
            int trainId = 0;
            int ticketsToCancel = 0;
            string classType = "";

            string queryBookingDetails = "SELECT TrainId, ClassType FROM Bookings WHERE BookingId = @BookingId AND UserId = @UserId";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(queryBookingDetails, connection))
                {
                    command.Parameters.AddWithValue("@BookingId", bookingId);
                    command.Parameters.AddWithValue("@UserId", UserId);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            trainId = Convert.ToInt32(reader["TrainId"]);
                            classType = reader["ClassType"].ToString();
                            ticketsToCancel = 1; // Assuming one ticket per booking for simplicity
                        }
                    }
                }

                if (trainId == 0 || ticketsToCancel == 0)
                {
                    Console.WriteLine("Error retrieving booking details.");
                    UserActionsAfterLogin();
                    return;
                }

                // Cancel the ticket by deleting from the Bookings table
                string queryCancelTicket = "DELETE FROM Bookings WHERE BookingId = @BookingId AND UserId = @UserId";

                using (SqlCommand command = new SqlCommand(queryCancelTicket, connection))
                {
                    command.Parameters.AddWithValue("@BookingId", bookingId);
                    command.Parameters.AddWithValue("@UserId", UserId);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        // Ticket canceled successfully, update available berths in Trains table
                        UpdateAvailableBerthsAfterCancellation(trainId, classType, ticketsToCancel);
                        Console.WriteLine("Ticket canceled successfully. Available berths updated.");
                    }
                    else
                    {
                        Console.WriteLine("Failed to cancel ticket.");
                    }
                }

                connection.Close();
            }

            UserActionsAfterLogin(); // Redirect back to actions after cancellation
        }


        static void ShowAvailableTrains()
        {
            string query = "SELECT TrainId, TrainName, FirstClassBerths, SecondClassBerths, SleeperBerths, Source, Destination FROM Trains WHERE IsActive = 1";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        Console.WriteLine("Available Trains:");
                        Console.WriteLine("---------------------------------------------");
                        while (reader.Read())
                        {
                            Console.WriteLine($"Train ID: {reader["TrainId"]}");
                            Console.WriteLine($"Train Name: {reader["TrainName"]}");
                            Console.WriteLine($"1st Class Berths: {reader["FirstClassBerths"]}");
                            Console.WriteLine($"2nd Class Berths: {reader["SecondClassBerths"]}");
                            Console.WriteLine($"Sleeper Berths: {reader["SleeperBerths"]}");
                            Console.WriteLine($"Route: {reader["Source"]} to {reader["Destination"]}");
                            Console.WriteLine("---------------------------------------------");
                        }
                    }
                }

                connection.Close();
            }

            UserActionsAfterLogin(); // Redirect back to actions after showing available trains
        }

        static int GetAvailableBerths(int trainId, string selectedClass)
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

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = $"SELECT {column} FROM Trains WHERE TrainId = @TrainId AND IsActive = 1";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@TrainId", trainId);

                    object result = command.ExecuteScalar();
                    if (result != null)
                    {
                        availableBerths = Convert.ToInt32(result);
                    }
                }

                connection.Close();
            }

            return availableBerths;
        }

        static bool CheckBookingExists(int bookingId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT COUNT(*) FROM Bookings WHERE BookingId = @BookingId AND UserId = @UserId";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@BookingId", bookingId);
                    command.Parameters.AddWithValue("@UserId", UserId);

                    int count = Convert.ToInt32(command.ExecuteScalar());
                    return count > 0;
                }

                connection.Close();
            }
        }

        static void UserBooking()
        {
            if (UserId == 0)
            {
                Console.WriteLine("Please log in to book tickets.");
                UserLogin();
            }

            Console.WriteLine("Enter Train ID to Book Ticket:");
            int trainId;
            if (!int.TryParse(Console.ReadLine(), out trainId))
            {
                Console.WriteLine("Invalid Train ID. Please enter a valid number.");
                ShowAvailableTrains();
                UserActionsAfterLogin();
                return;
            }

            Console.WriteLine("Select Class (1st/2nd/Sleeper):");
            string selectedClass = Console.ReadLine();

            Console.WriteLine("Enter Number of Tickets to Book (Max 5):");
            int ticketsToBook;
            if (!int.TryParse(Console.ReadLine(), out ticketsToBook) || ticketsToBook <= 0 || ticketsToBook > 5)
            {
                Console.WriteLine("Invalid number of tickets. Please enter a valid number (1-5).");
                UserActionsAfterLogin();
                return;
            }

            string[] passengerNames = new string[ticketsToBook];
            string[] passengerClassTypes = new string[ticketsToBook];
            int[] passengerAges = new int[ticketsToBook];

            for (int i = 0; i < ticketsToBook; i++)
            {
                Console.WriteLine($"Enter Details for Passenger {i + 1}:");
                Console.Write("Name: ");
                passengerNames[i] = Console.ReadLine();
                Console.Write("Class Type (1st/2nd/Sleeper): ");
                passengerClassTypes[i] = Console.ReadLine();
                Console.Write("Age: ");
                if (!int.TryParse(Console.ReadLine(), out passengerAges[i]) || passengerAges[i] <= 0)
                {
                    Console.WriteLine("Invalid age. Please enter a valid number.");
                    UserActionsAfterLogin();
                    return;
                }
            }

            // Book tickets
            BookTickets(trainId, selectedClass, ticketsToBook, passengerNames, passengerClassTypes, passengerAges);
        }

        static void BookTickets(int trainId, string selectedClass, int ticketsToBook, string[] passengerNames, string[] passengerClassTypes, int[] passengerAges)
        {
            // Generate a unique numeric PNR for this booking
            int pnr = GeneratePNR();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string bookingQuery = "INSERT INTO Bookings (UserId, TrainId, ClassType, PassengerName, PassengerAge, PNR) " +
                    "VALUES (@UserId, @TrainId, @ClassType, @PassengerName, @PassengerAge, @PNR)";

                using (SqlCommand command = new SqlCommand(bookingQuery, connection))
                {
                    command.Parameters.AddWithValue("@UserId", UserId);
                    command.Parameters.AddWithValue("@TrainId", trainId);
                    command.Parameters.AddWithValue("@ClassType", selectedClass);
                    command.Parameters.Add("@PassengerName", System.Data.SqlDbType.NVarChar);
                    command.Parameters.Add("@PassengerAge", System.Data.SqlDbType.Int);
                    command.Parameters.AddWithValue("@PNR", pnr); // Use the same PNR for all passengers in this transaction

                    for (int i = 0; i < ticketsToBook; i++)
                    {
                        command.Parameters["@PassengerName"].Value = passengerNames[i];
                        command.Parameters["@PassengerAge"].Value = passengerAges[i];
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected <= 0)
                        {
                            Console.WriteLine("Failed to book ticket for passenger: " + passengerNames[i]);
                        }
                    }

                    Console.WriteLine("Tickets booked successfully.");
                    Console.WriteLine("Thanks For Booking The Tickets");
                    Console.WriteLine($"Your PNR is: {pnr}");

                    // Update available berths after successful booking
                    UpdateAvailableBerths(trainId, selectedClass, ticketsToBook);
                }

                connection.Close();
            }

            UserActionsAfterLogin();
        }

        static void UpdateAvailableBerths(int trainId, string selectedClass, int ticketsToBook)
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

            string query = $"UPDATE Trains SET {column} = {column} - @TicketsToBook WHERE TrainId = @TrainId AND IsActive = 1";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@TicketsToBook", ticketsToBook);
                command.Parameters.AddWithValue("@TrainId", trainId);
                command.ExecuteNonQuery();
            }
        }

        static int GeneratePNR()
        {
            // Generate a random PNR for demonstration purposes
            Random random = new Random();
            return random.Next(100000, 999999);
        }

    }

    static class Admin
    {
        public static void AddTrain(SqlConnection connection)
        {
            Console.WriteLine("Enter Train ID:");
            int trainId;
            if (!int.TryParse(Console.ReadLine(), out trainId))
            {
                Console.WriteLine("Invalid Train ID. Please enter a valid number.");
                return;
            }

            Console.WriteLine("Enter Train Name:");
            string trainName = Console.ReadLine();

            Console.WriteLine("Enter Total Berths (1st Class):");
            int firstClassBerths;
            if (!int.TryParse(Console.ReadLine(), out firstClassBerths))
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
                return;
            }

            Console.WriteLine("Enter Total Berths (2nd Class):");
            int secondClassBerths;
            if (!int.TryParse(Console.ReadLine(), out secondClassBerths))
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
                return;
            }

            Console.WriteLine("Enter Total Berths (Sleeper):");
            int sleeperBerths;
            if (!int.TryParse(Console.ReadLine(), out sleeperBerths))
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
                return;
            }

            Console.WriteLine("Enter Source:");
            string source = Console.ReadLine();

            Console.WriteLine("Enter Destination:");
            string destination = Console.ReadLine();

            string query = "INSERT INTO Trains (TrainId, TrainName, FirstClassBerths, SecondClassBerths, SleeperBerths, Source, Destination, IsActive) " +
                           "VALUES (@TrainId, @TrainName, @FirstClassBerths, @SecondClassBerths, @SleeperBerths, @Source, @Destination, 1)";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@TrainId", trainId);
                command.Parameters.AddWithValue("@TrainName", trainName);
                command.Parameters.AddWithValue("@FirstClassBerths", firstClassBerths);
                command.Parameters.AddWithValue("@SecondClassBerths", secondClassBerths);
                command.Parameters.AddWithValue("@SleeperBerths", sleeperBerths);
                command.Parameters.AddWithValue("@Source", source);
                command.Parameters.AddWithValue("@Destination", destination);

                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                    Console.WriteLine("Train added successfully.");
                else
                    Console.WriteLine("Failed to add train.");
            }
        }

        /*
          public static void ModifyTrain(SqlConnection connection)
        {
            Console.WriteLine("Enter Train ID to Modify:");
            int trainId;
            if (!int.TryParse(Console.ReadLine(), out trainId))
            {
                Console.WriteLine("Invalid Train ID. Please enter a valid number.");
                return;
            }

            Console.WriteLine("Enter New Total Berths (1st Class):");
            int newFirstClassBerths;
            if (!int.TryParse(Console.ReadLine(), out newFirstClassBerths))
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
                return;
            }

            Console.WriteLine("Enter New Total Berths (2nd Class):");
            int newSecondClassBerths;
            if (!int.TryParse(Console.ReadLine(), out newSecondClassBerths))
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
                return;
            }

            Console.WriteLine("Enter New Total Berths (Sleeper):");
            int newSleeperBerths;
            if (!int.TryParse(Console.ReadLine(), out newSleeperBerths))
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
                return;
            }

            Console.WriteLine("Enter New Source:");
            string newSource = Console.ReadLine();

            Console.WriteLine("Enter New Destination:");
            string newDestination = Console.ReadLine();

            string query = "UPDATE Trains SET Source = @NewSource, Destination = @NewDestination WHERE TrainId = @TrainId AND IsActive = 1";
            FirstClassBerths = @NewFirstClassBerths, SecondClassBerths = @NewSecondClassBerths, " + "SleeperBerths = @NewSleeperBerths,
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@TrainId", trainId);
                command.Parameters.AddWithValue("@NewFirstClassBerths", newFirstClassBerths);
                command.Parameters.AddWithValue("@NewSecondClassBerths", newSecondClassBerths);
                command.Parameters.AddWithValue("@NewSleeperBerths", newSleeperBerths);
                command.Parameters.AddWithValue("@NewSource", newSource);
                command.Parameters.AddWithValue("@NewDestination", newDestination);

                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                    Console.WriteLine("Train modified successfully.");
                else
                    Console.WriteLine("Failed to modify train.");
            }
        }

        */

        public static void ModifyTrain(SqlConnection connection)
        {
            Console.WriteLine("Enter Train ID to Modify:");
            int trainId;
            if (!int.TryParse(Console.ReadLine(), out trainId))
            {
                Console.WriteLine("Invalid Train ID. Please enter a valid number.");
                return;
            }

            Console.WriteLine("Enter New Source:");
            string newSource = Console.ReadLine();

            Console.WriteLine("Enter New Destination:");
            string newDestination = Console.ReadLine();

            Console.WriteLine("Is the train active? (Enter '1' for active, '0' for inactive):");
            int isActive;
            if (!int.TryParse(Console.ReadLine(), out isActive) || (isActive != 0 && isActive != 1))
            {
                Console.WriteLine("Invalid input. Please enter '1' for active or '0' for inactive.");
                return;
            }

            string query = "UPDATE Trains SET Source = @NewSource, Destination = @NewDestination, IsActive = @IsActive WHERE TrainId = @TrainId";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@TrainId", trainId);
                command.Parameters.AddWithValue("@NewSource", newSource);
                command.Parameters.AddWithValue("@NewDestination", newDestination);
                command.Parameters.AddWithValue("@IsActive", isActive);

                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                    Console.WriteLine("Train modified successfully.");
                else
                    Console.WriteLine("Failed to modify train.");
            }
        }

        public static void DeleteTrain(SqlConnection connection)
        {
            Console.WriteLine("Enter Train ID to Delete:");
            int trainId;
            if (!int.TryParse(Console.ReadLine(), out trainId))
            {
                Console.WriteLine("Invalid Train ID. Please enter a valid number.");
                return;
            }

            string query = "UPDATE Trains SET IsActive = 0 WHERE TrainId = @TrainId AND IsActive = 1";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@TrainId", trainId);
                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                    Console.WriteLine("Train deleted successfully.");
                else
                    Console.WriteLine("Failed to delete train.");
            }
        }
        public static void ShowAllTrains(SqlConnection connection)
        {
            string query = "SELECT * FROM Trains";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    Console.WriteLine("Available Trains:");
                    Console.WriteLine("---------------------------------------------");
                    while (reader.Read())
                    {
                        Console.WriteLine($"Train ID: {reader["TrainId"]}");
                        Console.WriteLine($"Train Name: {reader["TrainName"]}");
                        Console.WriteLine($"1st Class Berths: {reader["FirstClassBerths"]}");
                        Console.WriteLine($"2nd Class Berths: {reader["SecondClassBerths"]}");
                        Console.WriteLine($"Sleeper Berths: {reader["SleeperBerths"]}");
                        Console.WriteLine($"Route: {reader["Source"]} to {reader["Destination"]}");
                        Console.WriteLine($"Train Available: {reader["IsActive"]}");
                        Console.WriteLine("---------------------------------------------");
                    }
                }
            }
        }
    }
}
