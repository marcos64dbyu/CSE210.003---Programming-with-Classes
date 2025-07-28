using OnlineOrdering;
using System;

class Program
{
    static void Main(string[] args)
    {
        // Dirección 1 (USA)
        Address address1 = new Address("123 Elm St", "Phoenix", "AZ", "USA");
        Customer customer1 = new Customer("Marco Merizalde", address1);
        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("Laptop", "LTP123", 999.99, 1));
        order1.AddProduct(new Product("Mouse", "MSE456", 25.50, 2));

        // Dirección 2 (internacional)
        Address address2 = new Address("45 Maple Road", "Toronto", "ON", "Canada");
        Customer customer2 = new Customer("Carlos Mendoza", address2);
        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("Camera", "CAM789", 450.00, 1));
        order2.AddProduct(new Product("Tripod", "TRP012", 80.00, 1));

        List<Order> orders = new List<Order> { order1, order2 };

        foreach (Order order in orders)
        {
            Console.WriteLine(order.GetShippingLabel());
            Console.WriteLine(order.GetPackingLabel());
            Console.WriteLine($"Total Cost: ${order.CalculateTotal():0.00}");
            Console.WriteLine(new string('-', 40));
        }
    }
}