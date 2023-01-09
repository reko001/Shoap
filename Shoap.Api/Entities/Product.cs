namespace Shoap.Api.Entities;

public record Product(int Id, string Name, string Description, decimal Price, int CategoryId);