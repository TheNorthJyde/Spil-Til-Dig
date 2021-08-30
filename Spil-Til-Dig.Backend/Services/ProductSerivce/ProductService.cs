using Spil_Til_Dig.Backend.Repos;
using Spil_Til_Dig.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spil_Til_Dig.Backend.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepo productRepo;

        public ProductService(IProductRepo productRepo)
        {
            this.productRepo = productRepo;
        }

        public async Task AddProductsFromCMS(List<Product> products)
        {
            await productRepo.AddRangeAsync(products);
            await productRepo.SaveAsync();
        }

        public async Task DeleteProductFromCMS(long id)
        {
            var product = await productRepo.FindAsync(x => x.Id == id);
            if (product != null)
            {
                productRepo.Remove(product);
            }
            await productRepo.SaveAsync();
        }

        public async Task UpdateProductFromCMS(Product product)
        {
            productRepo.Update(product);
            await productRepo.SaveAsync();
        }
    }
}
