using Microsoft.EntityFrameworkCore;
using Spil_Til_Dig.Backend.Repos;
using Spil_Til_Dig.Shared.Entities;
using Spil_Til_Dig.Shared.Models;
using Spil_Til_Dig.Shared.Wrappers;
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

        public async Task<PagedList<Product>> GetPagedProducts(Pagination pagination)
        {
            pagination.PreparePaging();
            var source = productRepo.GetAll();
            source = source.Include(k => k.Keys.Where(x => x.IsSold == false));
            if (!string.IsNullOrWhiteSpace(pagination.Search))
            {
                source = source.Where(x => x.Name.ToLower().Contains(pagination.Search));
            }
            if (pagination.GenreId != 0)
            {
                source = source.Where(x => x.Genres.Any(z => z.Id == pagination.GenreId));
            }
            if (pagination.MaxPrice != 0)
            {
                source = source.Where(x => x.Price < pagination.MaxPrice || (x.SalePrice < pagination.MaxPrice && x.IsOnSale));
            }
            if (pagination.IsOnSale)
            {
                source = source.Where(x => x.IsOnSale);
            }

            return await PagedList<Product>.CreateAsync(source, pagination);
        }

        public async Task<Product> GetProduct(long id)
        {
            return await productRepo.GetAsync(id);
        }

        public async Task UpdateProductFromCMS(Product product)
        {
            productRepo.Update(product);
            await productRepo.SaveAsync();
        }
    }
}
