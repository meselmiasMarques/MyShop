using System.Text.Json.Serialization;

namespace MyShop.Core.Model;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string ImageUrl { get; set; } = string.Empty;
    public int CategoryId { get; set; }
    [JsonIgnore]
    public Category Category { get; set; } =  new ();
}