using Blazored.LocalStorage;
using Spil_Til_Dig.Shared.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spil_Til_Dig.Web.Services
{
    public class CartService : ICartService
    {

        private ILocalStorageService localStorage;
        private string cascheName = "cartCashe";

        public event Action OnChange;

        public CartService(ILocalStorageService localStorage)
        {
            this.localStorage = localStorage;
        }


        public async Task AddToCart(ProductDTO product)
        {
            var products = await GetCart();
            products.Add(product);
            await localStorage.SetItemAsync(cascheName, products);
            OnChange?.Invoke();
        }

        public async Task RemoveFromCart(long id)
        {
            var products = await GetCart();
            products.Remove(products.FirstOrDefault(x => x.Id == id));
            await localStorage.SetItemAsync(cascheName, products);
            OnChange?.Invoke();
        }

        public async Task<List<ProductDTO>> GetCart()
        {
            var products = await localStorage.GetItemAsync<List<ProductDTO>>(cascheName);
            if (products == null)
            {
                products = new List<ProductDTO>();
            }
            return products;
        }

        public async Task EmptyCart()
        {
            await localStorage.SetItemAsync(cascheName, new List<ProductDTO>());
        }
    }
}
