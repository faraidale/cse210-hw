using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create first order (USA customer)
        Address address1 = new Address("123 Main Street", "Springfield", "IL", "USA");
        Customer customer1 = new Customer("Lesedi Smith", address1);
        Order order1 = new Order(customer1);

        Product product1 = new Product("Laptop Stand", "LS-001", 45.99, 1);
        Product product2 = new Product("Wireless Mouse", "WM-042", 25.50, 2);
        Product product3 = new Product("USB-C Cable", "UC-100", 12.99, 3);

        order1.AddProduct(product1);
        order1.AddProduct(product2);
        order1.AddProduct(product3);

        // Create second order (International customer)
        Address address2 = new Address("45 Victoria Street", "Harare", "Harare Province", "Zimbabwe");
        Customer customer2 = new Customer("Farai Rwambiwa", address2);
        Order order2 = new Order(customer2);

        Product product4 = new Product("Programming Book", "PB-205", 39.99, 1);
        Product product5 = new Product("Mechanical Keyboard", "MK-789", 89.99, 1);

        order2.AddProduct(product4);
        order2.AddProduct(product5);

        // Display Order 1
        Console.WriteLine("=== ORDER 1 ===");
        Console.WriteLine();
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine();
        Console.WriteLine($"Total Cost: ${order1.CalculateTotal():F2}");
        Console.WriteLine();
        Console.WriteLine("==================");
        Console.WriteLine();

        // Display Order 2
        Console.WriteLine("=== ORDER 2 ===");
        Console.WriteLine();
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine();
        Console.WriteLine($"Total Cost: ${order2.CalculateTotal():F2}");
        Console.WriteLine();
        Console.WriteLine("==================");
    }
}