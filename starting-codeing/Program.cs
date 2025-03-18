using System;
using System.Collections.Generic;

namespace InventoryManagementSystem
{
    // Class to represent a product
    class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }

        public Product(string name, double price, int stock)
        {
            Name = name;
            Price = price;
            Stock = stock;
        }
    }

    class Program
    {
        // List to store all products
        static List<Product> inventory = new List<Product>();

        // Function to add a new product
        static void AddProduct()
        {
            Console.Write("Enter product name: ");
            string name = Console.ReadLine();

            Console.Write("Enter product price: ");
            double price = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter stock quantity: ");
            int stock = Convert.ToInt32(Console.ReadLine());

            Product newProduct = new Product(name, price, stock);
            inventory.Add(newProduct);

            Console.WriteLine($"{name} added successfully!\n");
        }

        // Function to update stock
        static void UpdateStock()
        {
            Console.Write("Enter product name to update: ");
            string name = Console.ReadLine();

            foreach (Product product in inventory)
            {
                if (product.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine($"Current stock: {product.Stock}");
                    Console.Write("Enter quantity to add (+) or subtract (-): ");
                    int change = Convert.ToInt32(Console.ReadLine());

                    product.Stock += change;
                    Console.WriteLine($"Updated stock for {name}: {product.Stock}\n");
                    return;
                }
            }

            Console.WriteLine("Product not found!\n");
        }

        // Function to view all products
        static void ViewProducts()
        {
            if (inventory.Count == 0)
            {
                Console.WriteLine("Inventory is empty.\n");
                return;
            }

            Console.WriteLine("\nCurrent Inventory:");
            foreach (Product product in inventory)
            {
                Console.WriteLine($"Name: {product.Name}, Price: ${product.Price}, Stock: {product.Stock}");
            }
            Console.WriteLine();
        }

        // Function to remove a product
        static void RemoveProduct()
        {
            Console.Write("Enter product name to remove: ");
            string name = Console.ReadLine();

            for (int i = 0; i < inventory.Count; i++)
            {
                if (inventory[i].Name.Equals(name, StringComparison.OrdinalIgnoreCase))
                {
                    inventory.RemoveAt(i);
                    Console.WriteLine($"{name} removed successfully!\n");
                    return;
                }
            }

            Console.WriteLine("Product not found!\n");
        }

        // Main program loop
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Inventory Management System");
                Console.WriteLine("1. Add Product");
                Console.WriteLine("2. Update Stock");
                Console.WriteLine("3. View Products");
                Console.WriteLine("4. Remove Product");
                Console.WriteLine("5. Exit");

                Console.Write("Enter your choice (1-5): ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddProduct();
                        break;
                    case "2":
                        UpdateStock();
                        break;
                    case "3":
                        ViewProducts();
                        break;
                    case "4":
                        RemoveProduct();
                        break;
                    case "5":
                        Console.WriteLine("Exiting Inventory System. Goodbye!");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.\n");
                        break;
                }
            }
        }
    }
}
