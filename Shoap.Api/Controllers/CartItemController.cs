using Microsoft.AspNetCore.Mvc;
using Shoap.Api.Entities;
using Shoap.Api.Extensions;
using Shoap.Api.Repositories.Contracts;
using Shoap.Models.Dtos;

namespace Shoap.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CartItemController : ControllerBase
{
    private readonly ICartItemRepository _cartItemRepository;
    private readonly IProductRepository _productRepository;
    public CartItemController(ICartItemRepository cartItemRepository, IProductRepository productRepository)
    {
        _cartItemRepository = cartItemRepository;
        _productRepository = productRepository;
    }
    
    [HttpGet]
    [Route("{productId}_{userId}")]
    public async Task<ActionResult<CartItemDto>> GetCartItem(int productId, int userId)
    {
        try
        {
            var cartItem = await _cartItemRepository.GetCartItem(productId, userId);
            var products = await _productRepository.GetProducts();
            if(cartItem == null || products == null)
            {
                return NotFound();
            }
            return Ok(cartItem.ConvertToDto(products));
        }
        catch
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the server");
        }
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CartItemDto>>> GetCartItems()
    {
        try
        {
            var cartItems = await _cartItemRepository.GetCartItems();
            var products = await _productRepository.GetProducts();
            if(cartItems == null || products == null)
            {
                return NotFound();
            }
            return Ok(cartItems.ConverToDto(products));
        }
        catch
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the server");
        }
    }

    [HttpGet]
    [Route("{userId}")]
    public async Task<ActionResult<IEnumerable<CartItemDto>>> GetUserCartItems(int userId)
    {
        try
        {
            var cartItems = await _cartItemRepository.GetUserCartItems(userId);
            var products = await _productRepository.GetProducts();
            if (cartItems == null || products == null)
            {
                return NotFound();
            }
            return Ok(cartItems.ConverToDto(products));
        }
        catch
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the server");
        }
    }

    [HttpPost]
    public async Task<ActionResult> InsertCartItem(CartItemDto cartItemDto)
    {
        try
        {
            var existingItem = await _cartItemRepository.GetCartItem(cartItemDto.ProductId, cartItemDto.UserId);
            if(existingItem != null)
            {
                return StatusCode(StatusCodes.Status409Conflict, "Such cart item already exists");
            }
            CartItem cartItem = new() { ProductId = cartItemDto.ProductId, UserId = cartItemDto.UserId };
            await _cartItemRepository.InsertCartItem(cartItem);
            return Ok();
        }
        catch
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Error saving data to the server");
        }
    }

    [HttpDelete]
    public async Task<ActionResult> DeleteCartItem(int productId, int userId)
    {
        try
        {
            CartItem cartItem = new() { ProductId = productId, UserId = userId };
            var existingItem = await _cartItemRepository.GetCartItem(productId, userId);
            if(existingItem == null) 
            {
                return NotFound();
            }
            await _cartItemRepository.DeleteCartItem(productId, userId);
            return Ok();
        }
        catch
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting data from the server");
        }
    }
}
