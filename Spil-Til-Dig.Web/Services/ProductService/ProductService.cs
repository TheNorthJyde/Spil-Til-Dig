using Spil_Til_Dig.Shared.Models;
using Spil_Til_Dig.Shared.Models.DTO;
using Spil_Til_Dig.Shared.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Spil_Til_Dig.Web.Services
{
    public class ProductService : IProductService
    {
        private HttpClient client;

        public ProductService(HttpClient client)
        {
            this.client = client;
        }

        public async Task<ProductDTO> GetProduct(long id)
        {
            try
            {
                return await client.GetFromJsonAsync<ProductDTO>("product/" + id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public async Task<PagedList<ProductDTO>> GetProducts(Pagination pagination)
        {
            try
            {
                return await client.GetFromJsonAsync<PagedList<ProductDTO>>("product" + pagination.AsQuery());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }
    }
}
