using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Spil_Til_Dig.Shared.Models.PayPal;
using Spil_Til_Dig.Backend.Options;
using Spil_Til_Dig.Backend.Repos;
using Spil_Til_Dig.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Spil_Til_Dig.Shared.Models.DTO;
using AutoMapper;

namespace Spil_Til_Dig.Backend.Services
{
    public class PayPalService : IPayPalService
    {
        private HttpClient client;
        private readonly IOptions<PayPalOptions> options;
        private readonly IOrderRepo orderRepo;
        private readonly IKeyRepo keyRepo;
        protected readonly IMapper mapper;

        public PayPalService(HttpClient client, IOptions<PayPalOptions> options, IOrderRepo orderRepo, IKeyRepo keyRepo, IMapper mapper)
        {
            this.client = client;
            this.options = options;
            this.orderRepo = orderRepo;
            this.keyRepo = keyRepo;
            this.mapper = mapper;
        }

        private async Task SetToken()
        {
            using (var request = new HttpRequestMessage(new HttpMethod("POST"), $"{options.Value.URL}/v1/oauth2/token"))
            {
                request.Headers.TryAddWithoutValidation("Accept", "application/json");
                request.Headers.TryAddWithoutValidation("Accept-Language", "en_US");

                var base64authorization = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{options.Value.ClientId}:{options.Value.Secret}"));
                request.Headers.TryAddWithoutValidation("Authorization", $"Basic {base64authorization}");

                request.Content = new StringContent("grant_type=client_credentials");
                request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/x-www-form-urlencoded");

                var response = await client.SendAsync(request);
                var token = JsonSerializer.Deserialize<Token>(await response.Content.ReadAsStringAsync());
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.ToString());
            }
        }

        public async Task<PayPalOrderCreated> CreateOrder(List<Product> products, string userId)
        {
            await SetToken();
            PayPalOrder payPalOrder = new PayPalOrder();
            Guid invoiceId = Guid.NewGuid();
            PurchaseUnit purchaseUnit = new PurchaseUnit();
            purchaseUnit.invoice_id = invoiceId.ToString();
            AmountWithBreakdown amount = new AmountWithBreakdown();
            amount.currency_code = "DKK";
            Order order = new Order();
            var keys = keyRepo.GetAll().Where(x => !x.IsSold);
            foreach (var product in products)
            {
                Item item = new Item();
                item.sku = product.Id.ToString();
                item.name = product.Name;
                var price = product.IsOnSale ? product.SalePrice : product.Price;
                item.unit_amount = new Money { currency_code = "DKK", value = price };
                purchaseUnit.items.Add(item);
                amount.value += price;
                var key = await keys.FirstOrDefaultAsync(x => x.ProductId == product.Id);
                key.IsSold = true;
                keyRepo.Update(key);
                order.Keys.Add(key);
            }
            amount.breakdown.item_total = new Money(){ currency_code = "DKK", value = amount.value };
            purchaseUnit.amount = amount;
            payPalOrder.purchase_units.Add(purchaseUnit);
            var respone = await client.PostAsJsonAsync($"{options.Value.URL}/v2/checkout/orders", payPalOrder);
            var created = await respone.Content.ReadFromJsonAsync<PayPalOrderCreated>();
            order.Id = created.id;
            order.IsPaid = false;
            order.InvoiceId = invoiceId.ToString();
            order.UserId = userId;

            await orderRepo.AddAsync(order);
            await orderRepo.SaveAsync();
            return created;
        }

        public async Task<CaptureCompletedDTO> CaptureOrder(string orderNumber)
        {
            await SetToken();
            var response = await client.PostAsJsonAsync<Order>($"{options.Value.URL}/v2/checkout/orders/{orderNumber}/capture", null);
            if (response.IsSuccessStatusCode)
            {
                var capture = await response.Content.ReadFromJsonAsync<PaypalCapureComplete>();
                var order = await orderRepo.GetAsync(orderNumber);
                order.IsPaid = true;
                orderRepo.Update(order);
                await orderRepo.SaveAsync();
                return new CaptureCompletedDTO { CompleteCaputre = capture, Keys = mapper.Map<List<ProductKeyDTO>>(order.Keys) };
            }
            return null;
        }
    }

    internal class Token
    {
        public string access_token { get; set; }

        public override string ToString()
        {
            return access_token;
        }
    }
}
