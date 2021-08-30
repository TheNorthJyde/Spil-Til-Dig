using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Spil_Til_Dig.Backend.Attributes;
using Spil_Til_Dig.Backend.Services;
using Spil_Til_Dig.Shared.Entities;
using Spil_Til_Dig.Shared.Models;
using Spil_Til_Dig.Shared.Models.DTO;
using Spil_Til_Dig.Shared.Wrappers;
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
        protected readonly IMapper mapper;
        public ProductController(IProductService productService, IMapper mapper)
        {
            this.productService = productService;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts([FromQuery] Pagination pagination)
        {
            if (pagination == null)
            {
                pagination = new Pagination();
            }
            
            var list = await productService.GetPagedProducts(pagination);
            var dest = mapper.Map<PagedList<Product>, PagedList<ProductDTO>>(list);
            dest.Paging = list.Paging;
            return Ok(dest);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(long id)
        {
            return Ok(mapper.Map<ProductDTO>(await productService.GetProduct(id)));
        }

        [HttpPost]
        [ApiKey]
        public async Task<IActionResult> CreateProducts([FromBody] List<Product> products)
        {
            await productService.AddProductsFromCMS(products);
            return Ok();
        }

        [HttpPut("{id}")]
        [ApiKey]
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
        [ApiKey]
        public async Task<IActionResult> DeleteProduct(long id)
        {
            await productService.DeleteProductFromCMS(id);
            return Ok();
        }
    }
}
