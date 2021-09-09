using Spil_Til_Dig.Shared.Models;
using Spil_Til_Dig.Shared.Models.DTO;
using Spil_Til_Dig.Shared.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spil_Til_Dig.Web.Services
{
    public interface IProductService
    {
        Task<PagedList<ProductDTO>> GetProducts(Pagination pagination);
        Task<ProductDTO> GetProduct(long id);
    }
}
