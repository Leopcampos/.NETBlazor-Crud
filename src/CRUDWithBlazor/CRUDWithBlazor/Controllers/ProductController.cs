using CRUDWithBlazor.Implementations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SharedLibrary.Models;
using SharedLibrary.Repositories;

namespace CRUDWithBlazor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet("All-Products")]
        public async Task<ActionResult<List<Product>>> GetAllProductsAsync()
        {
            var products = await _productRepository.GetAllProductsAsync();
            return Ok(products);
        }
        
        [HttpGet("Single-Product/{id}")]
        public async Task<ActionResult<List<Product>>> GetSingleProductsAsync(int id)
        {
            var product = await _productRepository.GetProductByIdAsync(id);
            return Ok(product);
        }

        [HttpPost("Add-Product")]
        public async Task<ActionResult<List<Product>>> AddProductAsync(Product model)
        {
            var product = await _productRepository.AddProductAsync(model);
            return Ok(product);
        }

        [HttpPut("Update-Product")]
        public async Task<ActionResult<List<Product>>> UpdateProductAsync(Product model)
        {
            var product = await _productRepository.UpdateProductAsync(model);
            return Ok(product);
        }

        [HttpDelete("Delete-Product/{id}")]
        public async Task<ActionResult<List<Product>>> DeleteProductAsync(int id)
        {
            var product = await _productRepository.DeleteProductAsync(id);
            return Ok(product);
        }
    }
}