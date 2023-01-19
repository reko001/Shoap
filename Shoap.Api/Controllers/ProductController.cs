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
	public async Task<ActionResult<IEnumerable<ProductDto>>> GetProducts()
	{
		try
		{
			var products = await _productRepository.GetProducts();
			var productCategories = await _productRepository.GetCategories();

			if(products == null || productCategories == null) 
			{
				return NotFound();
			}
			else
			{
				var productDtos = products.ConvertToDto(productCategories);
				return Ok(productDtos);
			}
		}
		catch
		{
			return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the server");
		}
	}

	[HttpGet]
	[Route("{id}")]
	public async Task<ActionResult<ProductDto>> GetProduct(int id)
	{
		try
		{
			var product = await _productRepository.GetProduct(id);
            var categories = await _productRepository.GetCategories();
			if(product == null || categories == null)
			{
				return NotFound();
			}
			var productDto = product.ConverToDto(categories);
			return Ok(productDto);

        }
        catch
		{
            return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the server");
        }
    }

	[HttpGet]
	[Route(nameof(GetCategories))]
	public async Task<ActionResult<IEnumerable<ProductCategoryDto>>> GetCategories()
	{
		try
		{
			var categories = await _productRepository.GetCategories();
			if(categories == null)
			{
				return NotFound();
			}
			var categoryDtos = categories.ConvertToDto();
			return Ok(categoryDtos);
		}
		catch
		{
            return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the server");
        }
    }
}
