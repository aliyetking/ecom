using ECom.API.Models;
using ECom.Application.Interfaces;
using ECom.Application.Models;
using Microsoft.AspNetCore.Mvc;

namespace ECom.API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }
    
    [HttpGet()]
    public async Task<BaseResponse<List<ProductListItemDto>>> ListAllProducts(CancellationToken ct)
    {
        return new BaseResponse<List<ProductListItemDto>>(await _productService.ListAllProducts(ct));
    }

    [HttpPost()]
    public async Task<BaseResponse<string>> CreateProduct([FromBody] CreateProductDto dto, CancellationToken ct)
    {
        await _productService.CreateProduct(dto, ct);
        return new BaseResponse<string>(null, "Success", "201");
    }
}