using Spil_Til_Dig.Shared.Entities;
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
    }
}
