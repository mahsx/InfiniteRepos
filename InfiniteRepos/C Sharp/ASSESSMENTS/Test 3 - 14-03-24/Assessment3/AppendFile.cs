using System;
using System.IO;

namespace AppendTextToFile
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string filePath = @"test3.txt"; // Specified the file path

                // after append you can find the file in - C:\Users\maheshsek\source\repos\Assessment3\Assessment3\bin\Debug 

                // Create or append to the file
                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    Console.WriteLine("Enter the text to append:");
                    string textToAppend = Console.ReadLine();

                    // Write the text to the file
                    writer.WriteLine(textToAppend);
                    Console.WriteLine("Text appended successfully!");
                    // whatever the changes is there you can get in - Assessment3\Assessment3\bin\Debug
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            Console.ReadKey();
        }
    }
}
