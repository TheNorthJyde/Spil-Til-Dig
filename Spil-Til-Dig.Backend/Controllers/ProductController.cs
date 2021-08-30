using Microsoft.AspNetCore.Mvc;
using Spil_Til_Dig.Backend.Services;
using Spil_Til_Dig.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Spil_Til_Dig.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        //[HttpGet]
        //public async Task<IActionResult> GetProducts()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //[HttpGet("{id}")]
        //public async Task GetProduct(int id)
        //{
        //    return "value";
        //}

        [HttpPost]
        public async Task<IActionResult> CreateProducts([FromBody] List<Product> products)
        {
            await productService.AddProductsFromCMS(products);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(long id, [FromBody] Product product)
        {
            if (id == product.Id)
            {
                await productService.UpdateProductFromCMS(product);
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(long id)
        {
            await productService.DeleteProductFromCMS(id);
            return Ok();
        }
    }
}
