using System;

class Product
{
    public int Product_Id { get; set; }
    public string Product_Name { get; set; }
    public double Product_Price { get; set; }
}

class ProductSorter
{
    public static void Main()
    {
        Product[] products = new Product[10];

        Console.WriteLine("Product Details");

        Console.WriteLine("Enter details of products  ");
        for (int i = 0; i < products.Length; i++)
        {
            Console.Write($"Product {i + 1}  ID -> ");
            int productId = int.Parse(Console.ReadLine());
            Console.Write($"Product {i + 1}  Name: ");
            string productName = Console.ReadLine();
            Console.Write($"Product {i + 1}  Price: ");
            double price = double.Parse(Console.ReadLine());

            products[i] = new Product { Product_Id = productId, Product_Name = productName, Product_Price = price };
        }

        // Sorting 
        Array.Sort(products, (a, b) => a.Product_Price.CompareTo(b.Product_Price));


        Console.WriteLine("Sorted Products based on Price:");
        foreach (Product product in products)
        {
            Console.WriteLine($"Product ID: {product.Product_Id}, Name: {product.Product_Name}, Price: {product.Product_Price}");
        }
    }
}