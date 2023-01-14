using System.ComponentModel.DataAnnotations.Schema;

namespace Shoap.Api.Entities;

[Table("products")]
public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
    [Column("IMAGE_URL")]
    public string ImageUrl { get; set; }
    public int Visits { get; set; }
    [Column("CATEGORY_ID")]
    public int CategoryId { get; set; }
}