using System;
using System.Collections.Generic;

public interface IEntity
{
    int Id { get; set; }
}

public interface IRepository<T> where T : IEntity
{
    void Add(T item);
    void Delete(T item);
    T FindById(int id);
    IEnumerable<T> GetAll();
}

public class Product : IEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Category { get; set; }

    public override string ToString()
    {
        return $"Product [Id={Id}, Name={Name}, Price={Price}, Category={Category}]";
    }
}

public class Customer : IEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string Email { get; set; }

    public override string ToString()
    {
        return $"Customer [Id={Id}, Name={Name}, Address={Address}, Email={Email}]";
    }
}

public class ProductRepository : IRepository<Product>
{
    private List<Product> products = new List<Product>();

    public void Add(Product item)
    {
        products.Add(item);
    }

    public void Delete(Product item)
    {
        products.Remove(item);
    }

    public Product FindById(int id)
    {
        return products.Find(p => p.Id == id);
    }

    public IEnumerable<Product> GetAll()
    {
        return products;
    }
}

public class CustomerRepository : IRepository<Customer>
{
    private List<Customer> customers = new List<Customer>();

    public void Add(Customer item)
    {
        customers.Add(item);
    }

    public void Delete(Customer item)
    {
        customers.Remove(item);
    }

    public Customer FindById(int id)
    {
        return customers.Find(c => c.Id == id);
    }

    public IEnumerable<Customer> GetAll()
    {
        return customers;
    }
}

class Program
{
    static void Main()
    {
        var productRepo = new ProductRepository();
        productRepo.Add(new Product { Id = 1, Name = "Laptop", Price = 999.99m, Category = "Electronics" });
        productRepo.Add(new Product { Id = 2, Name = "Mouse", Price = 25.50m, Category = "Electronics" });

        var customerRepo = new CustomerRepository();
        customerRepo.Add(new Customer { Id = 1, Name = "John", Address = "Street 1", Email = "john@mail.com" });
        customerRepo.Add(new Customer { Id = 2, Name = "Alice", Address = "Street 2", Email = "alice@mail.com" });

        Console.WriteLine("All Products:");
        foreach (var product in productRepo.GetAll())
        {
            Console.WriteLine(product);
        }

        Console.WriteLine("\nAll Customers:");
        foreach (var customer in customerRepo.GetAll())
        {
            Console.WriteLine(customer);
        }

        Console.WriteLine($"\nProduct with ID 1: {productRepo.FindById(1)}");
        Console.WriteLine($"Customer with ID 2: {customerRepo.FindById(2)}");
    }
}