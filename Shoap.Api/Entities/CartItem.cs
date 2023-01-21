using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shoap.Api.Entities;

[Table("cart_items")]
[PrimaryKey("ProductId", "UserId")]
public class CartItem
{
    [Column("product_id")]
    public int ProductId;
    [Column("user_id")]
    public int UserId;
}
