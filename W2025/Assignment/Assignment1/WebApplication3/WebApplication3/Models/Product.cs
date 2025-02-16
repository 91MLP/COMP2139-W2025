namespace WebApplication3.Models;

public class Product
{
    public int ProductId { get; set; }
    public string ProductName { get; set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; }
    public decimal Price { get; set; }
    public int QuantityInStock { get; set; }
    public int LowStockThreshold { get; set; }
}