using System;

class Program
{
    static void Main(string[] args)
    {
        // First customer and order (USA)
        Address address1 = new Address("123 Apple St", "Pasco", "WA", "USA");
        Customer customer1 = new Customer("Brenna Nery", address1);

        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("Laptop", "A100", 999.99, 1));
        order1.AddProduct(new Product("Mouse", "A200", 25.50, 2));

        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Cost: ${order1.GetTotalCost():F2}");
        Console.WriteLine(new string('-', 40));

        // Second customer and order (International)
        Address address2 = new Address("1234 Saddle Creek Lane", "Pasco", "WA", "USA");
        Customer customer2 = new Customer("Brenna Nery", address2);

        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("Headphones", "B300", 75.00, 1));
        order2.AddProduct(new Product("Microphone", "B400", 120.00, 1));
        order2.AddProduct(new Product("Webcam", "B500", 89.99, 1));

        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Cost: ${order2.GetTotalCost():F2}");
    }
}
