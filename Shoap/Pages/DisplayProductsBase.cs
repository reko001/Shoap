using Microsoft.AspNetCore.Components;
using Shoap.Models.Dtos;

namespace Shoap.Pages;

public class DisplayProductsBase : ComponentBase
{
    [Parameter]
    public IEnumerable<ProductDto> Products { get; set; }
}
