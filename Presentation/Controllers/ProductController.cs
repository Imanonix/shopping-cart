using Application.DTOs;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService) 
        {
            _productService = productService;
        }

        [Route("/CreateProduct")]
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] ProductDTO productDTO)
        {
            if (productDTO == null)
            {
                return BadRequest("information not completed");
            }
            
            await _productService.AddProductAsync(productDTO);

            return Ok(true);
        }
    }
}
