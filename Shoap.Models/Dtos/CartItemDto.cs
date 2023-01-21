namespace Shoap.Models.Dtos;

public class CartItemDto
{
    public int ProductId { get; set; }
    public int UserId { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }

    public override int GetHashCode()
    {
        int hash = 17;
        hash ^= ProductId.GetHashCode() * 19;
        hash ^= UserId.GetHashCode() * 19;
        hash ^= Name.GetHashCode() * 19;
        hash ^= Price.GetHashCode() * 19;
        return hash;
    }
}
