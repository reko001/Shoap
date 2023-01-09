using Shoap.Api.Entities;
using Shoap.Models.Dtos;

namespace Shoap.Api.Extensions;

public static class DtoConversions
{
    public static IEnumerable<ProductDto> ConverToDto(this IEnumerable<Product> products, IEnumerable<ProductCategory> productCategories)
    {
        return (from product in products
                join category in productCategories
                    on product.Id equals category.Id
                select new ProductDto()
                {
                    Id = product.Id,
                    Name = product.Name,
                    Description = product.Description,
                    Price = product.Price,
                    CategoryId = product.CategoryId,
                    CategoryName = category.Name
                }).ToList();
    }
}
