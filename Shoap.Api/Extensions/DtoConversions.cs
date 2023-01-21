using Shoap.Api.Entities;
using Shoap.Models.Dtos;

namespace Shoap.Api.Extensions;

public static class DtoConversions
{
    public static IEnumerable<ProductDto> ConvertToDto(this IEnumerable<Product> products, IEnumerable<ProductCategory> productCategories)
    {
        return (from product in products
                join category in productCategories
                on product.CategoryId equals category.Id
                select new ProductDto()
                {
                    Id = product.Id,
                    Name = product.Name,
                    Description = product.Description,
                    Price = product.Price,
                    ImageUrl = product.ImageUrl,
                    Visits = product.Visits,
                    CategoryId = product.CategoryId,
                    CategoryName = category.Name
                }).ToList();
    }

    public static IEnumerable<ProductCategoryDto> ConvertToDto(this IEnumerable<ProductCategory> productCategories)
    {
        return (from category in productCategories
                select new ProductCategoryDto
                {
                    Id = category.Id,
                    Name = category.Name,
                }).ToList();
    }

    public static ProductDto ConverToDto(this Product product, IEnumerable<ProductCategory> productCategories)
    {
        var categoryName = productCategories.First(category => category.Id == product.CategoryId).Name;
        return new ProductDto()
        {
            Id = product.Id,
            Name = product.Name,
            Description = product.Description,
            Price = product.Price,
            ImageUrl = product.ImageUrl,
            Visits = product.Visits,
            CategoryId = product.CategoryId,
            CategoryName = categoryName
        };
    }

    public static UserDto ConvertToDto(this User user)
    {
        return new UserDto()
        {
            Id = user.Id,
            Login = user.Login,
            Password = user.Password,
            Money = user.Money,
        };
    }

    public static CartItemDto ConvertToDto(this CartItem cartItem)
    {
        return new CartItemDto()
        {
            ProductId = cartItem.ProductId,
            UserId = cartItem.UserId
        };
    }

    public static IEnumerable<CartItemDto> ConverToDto(this IEnumerable<CartItem> cartItems)
    {
        return cartItems.Select(cartItem => cartItem.ConvertToDto());
    }
}
