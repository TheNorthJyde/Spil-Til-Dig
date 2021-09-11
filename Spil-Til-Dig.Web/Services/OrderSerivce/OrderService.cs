using Microsoft.Identity.Web;
using Spil_Til_Dig.Shared.Models;
using Spil_Til_Dig.Shared.Models.DTO;
using Spil_Til_Dig.Shared.Models.PayPal;
using Spil_Til_Dig.Shared.Wrappers;
using Spil_Til_Dig.Web.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace Spil_Til_Dig.Web.Services
{
    public class OrderService : IOrderService
    {
        private HttpClient client;
        private readonly TokenProvider tokenProvider;
        public OrderService(HttpClient client, TokenProvider tokenProvider)
        {
            this.client = client;
            this.tokenProvider = tokenProvider;
        }

        public async Task<CaptureCompletedDTO> CaputreOrder(string orderNumber)
        {
            
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", tokenProvider.AccessToken);
            try
            {
                var result = await client.PostAsync("order/capture/" + orderNumber, null);
                return await result.Content.ReadFromJsonAsync<CaptureCompletedDTO>();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<PayPalOrderCreated> CreateOrder(List<ProductDTO> products)
        {
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", tokenProvider.AccessToken);
            try
            {
                var result = await client.PostAsJsonAsync("order", new CreateOrderDTO { Products = products });
                return await result.Content.ReadFromJsonAsync<PayPalOrderCreated>();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<PagedList<OrderDTO>> GetOrders(Pagination pagination)
        {
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", tokenProvider.AccessToken);
            try
            {
                return await client.GetFromJsonAsync<PagedList<OrderDTO>>("order" + pagination.AsQuery());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }
    }
}
