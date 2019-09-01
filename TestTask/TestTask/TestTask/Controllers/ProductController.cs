using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestTask.Application.Models;
using TestTask.Data.Models;
using TestTast.Application;
using TestTast.Application.Models;

namespace TestTask.Web.Controllers
{
    [ApiController]
    [Route("site/api/[controller]")]
    public class ProductController:ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<List<Product>> GetProduct()
        {
            return await _productService.GetProduct();
        }

        [HttpPost]
        public async Task<Product> CreateProduct([FromBody] CreateProduct createProduct)
        {
            return await _productService.CreateProduct(createProduct.Name, createProduct.Price);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProduct([FromBody] ProductInfo input)
        {
            await _productService.DeleteProduct(input.Id);
            return Ok();
        }
    }
}
