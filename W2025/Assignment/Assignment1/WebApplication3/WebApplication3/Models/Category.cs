using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Models;

public class Category
{
    public int CategoryId { get; set; }
    public string CategoryName { get; set; }
    [Required]
    public string Description { get; set; }
}