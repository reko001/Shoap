using System.ComponentModel.DataAnnotations.Schema;

namespace Shoap.Api.Entities;

[Table("product_categories")]
public class ProductCategory
{
    public int Id { get; set; }
    public string Name { get; set; }
}