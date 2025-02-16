namespace WebApplication3.Models;

public class Order
{
    public int OrderId { get; set; }
    public string GuestName { get; set; }
    public string GuestEmail { get; set; }
    public DateTime OrderDate { get; set; }
    public decimal TotalPrice { get; set; }
    public List<OrderDetail> OrderDetails { get; set; }
}