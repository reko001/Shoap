using Microsoft.AspNetCore.Mvc;
using Shoap.Api.Extensions;
using Shoap.Api.Repositories.Contracts;
using Shoap.Models.Dtos;

namespace Shoap.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
	private readonly IProductRepository _productRepository;
	public ProductController(IProductRepository productRepository)
	{
		_productRepository = productRepository;
	}

	[HttpGet]
	public async Task<ActionResult<IEnumerable<ProductDto>>> GetItems()
	{
		try
		{
			var products = await _productRepository.GetItems();
			var productCategories = await _productRepository.GetCategories();

			if(products == null || productCategories == null) 
			{
				return NotFound();
			}
			else
			{
				var productDtos = products.ConverToDto(productCategories);
				return Ok(productDtos);
			}
		}
		catch (Exception)
		{
			return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the server");
		}
	}
}
