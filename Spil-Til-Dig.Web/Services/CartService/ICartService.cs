using Spil_Til_Dig.Shared.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spil_Til_Dig.Web.Services
{
    public interface ICartService
    {
        Task AddToCart(ProductDTO product);
        Task RemoveFromCart(long id);
        Task<List<ProductDTO>> GetCart();
        Task EmptyCart();
        event Action OnChange;

    }
}
