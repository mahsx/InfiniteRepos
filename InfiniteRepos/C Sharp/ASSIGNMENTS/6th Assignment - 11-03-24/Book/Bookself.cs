using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book
{
    class Books
    {
        public string BookName { get; set; }
        public string AuthorName { get; set; }

        // Constructor to initialize BookName and AuthorName
        public Books(string bookName, string authorName)
        {
            BookName = bookName;
            AuthorName = authorName;
        }

        // Method to display book details
        public void Display()
        {
            Console.WriteLine($"Book Name: {BookName}, Author Name: {AuthorName}");
        }
    }

    // Define the BookShelf class
    class BookShelf
    {
        private Books[] books = new Books[5];

        // Indexer to access books
        public Books this[int index]
        {
            get { return books[index]; }
            set { books[index] = value; }
        }
    }

    class Bookself
    {
        static void Main()
        {
            // Instantiate the BookShelf class
            BookShelf bookshelf = new BookShelf();

            // Assign values to the books using the indexer
            bookshelf[0] = new Books("Book1", "Banu Rekha 1");
            bookshelf[1] = new Books("Book2", "Banu Rekha 2");
            bookshelf[2] = new Books("Book3", "Banu Rekha 3");
            bookshelf[3] = new Books("Book4", "Banu Rekha 4");
            bookshelf[4] = new Books("Book5", "Banu Rekha 5");

            // Display the details of the books
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Book {i + 1}:");
                bookshelf[i].Display();
                Console.WriteLine();
                Console.ReadKey();
            }
        }
    }

}
