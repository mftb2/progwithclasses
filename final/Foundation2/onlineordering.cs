using System;
using System.Collections.Generic;

class Product
{
    public string Name { get; private set; }
    public int ProductId { get; private set; }
    public decimal Price { get; private set; }
    public int Quantity { get; private set; }

    public Product(string name, int productId, decimal price, int quantity)
    {
        Name = name;
        ProductId = productId;
        Price = price;
        Quantity = quantity;
    }
}

class Address
{
    public string StreetAddress { get; private set; }
    public string City { get; private set; }
    public string State { get; private set; }
    public string Country { get; private set; }

    public Address(string streetAddress, string city, string state, string country)
    {
        StreetAddress = streetAddress;
        City = city;
        State = state;
        Country = country;
    }

    public bool IsInUSA()
    {
        return Country == "USA";
    }

    public string GetFormattedAddress()
    {
        return $"{StreetAddress}, {City}, {State}, {Country}";
    }
}

class Customer
{
    public string Name { get; private set; }
    public Address Address { get; private set; }

    public Customer(string name, Address address)
    {
        Name = name;
        Address = address;
    }

    public bool IsInUSA()
    {
        return Address.IsInUSA();
    }
}

class Order
{
    public List<Product> Products { get; private set; }
    public Customer Customer { get; private set; }

    public Order(List<Product> products, Customer customer)
    {
        Products = products;
        Customer = customer;
    }

    public decimal CalculateTotalPrice()
    {
        decimal totalPrice = 0;
        foreach (var product in Products)
        {
            totalPrice += product.Price * product.Quantity;
        }
        totalPrice += Customer.IsInUSA() ? 5.0M : 35.0M; // Shipping cost
        return totalPrice;
    }

    public string GetPackingLabel()
    {
        string label = "Packing Label:\n";
        foreach (var product in Products)
        {
            label += $"Product: {product.Name}, ID: {product.ProductId}\n";
        }
        return label;
    }

    public string GetShippingLabel()
    {
        string label = "Shipping Label:\n";
        label += $"Customer: {Customer.Name}\n";
        label += $"Address: {Customer.Address.GetFormattedAddress()}\n";
        return label;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Address address1 = new Address("123 Main St", "City1", "State1", "USA");
        Address address2 = new Address("456 Elm St", "City2", "State2", "Canada");

        Customer customer1 = new Customer("Customer A", address1);
        Customer customer2 = new Customer("Customer B", address2);

        List<Product> products1 = new List<Product>
        {
            new Product("Product 1", 1, 10.0M, 3),
            new Product("Product 2", 2, 20.0M, 2),
        };

        List<Product> products2 = new List<Product>
        {
            new Product("Product 3", 3, 15.0M, 4),
        };

        Order order1 = new Order(products1, customer1);
        Order order2 = new Order(products2, customer2);

        // Display order details
        Console.WriteLine("Order 1:");
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order1.CalculateTotalPrice():F2}");

        Console.WriteLine("\nOrder 2:");
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order2.CalculateTotalPrice():F2}");
    }
}
