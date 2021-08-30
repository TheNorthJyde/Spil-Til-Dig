using Spil_Til_Dig.Shared.Entities;
using Spil_Til_Dig.Shared.Models;
using Spil_Til_Dig.Shared.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spil_Til_Dig.Backend.Services
{
    public interface IProductService
    {
        Task AddProductsFromCMS(List<Product> products);
        Task UpdateProductFromCMS(Product product);
        Task DeleteProductFromCMS(long id);
        Task<PagedList<Product>> GetPagedProducts(Pagination pagination);
        Task<Product> GetProduct(long id);
    }
}
