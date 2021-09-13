using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Spil_Til_Dig.Shared.Models.DTO;
using Spil_Til_Dig.Shared.Models.PayPal;
using Spil_Til_Dig.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spil_Til_Dig.Web.Pages.CheckoutPages
{
    public partial class Checkout : IDisposable
    {
        [Inject]
        ICartService CartService { get; set; }

        [Inject]
        IOrderService OrderService { get; set; }

        [Inject]
        IJSRuntime jS { get; set; }
        
        bool OrderIsComplete = false;
        List<ProductKeyDTO> productKeys = new List<ProductKeyDTO>();
        PaypalCapureComplete paypalCapure;
        private DotNetObjectReference<Checkout> objRef;

        
        List<ProductDTO> Products = new List<ProductDTO>();

        public decimal TotalPrice { get 
            {
                decimal price = 0;
                foreach (var product in Products)
                {
                    price += product.IsOnSale ? product.SalePrice : product.Price;
                }
                return price;
            } }

        public decimal FullPrice
        {
            get
            {
                decimal price = 0;
                foreach (var product in Products)
                {
                    price += product.Price;
                }
                return price;
            }
        }

        public decimal FullDiscount
        {
            get
            {
                decimal price = 0;
                foreach (var product in Products)
                {
                    price += product.SalePrice;
                }
                return price;
            }
        }

        protected override void OnInitialized()
        {
            objRef = DotNetObjectReference.Create(this);
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            Products = await CartService.GetCart();
            

            if (firstRender)
            {
                await jS.InvokeVoidAsync("Paypal", objRef);
            }
            StateHasChanged();
        }

        [JSInvokable]
        public async Task<PayPalOrderCreated> CreateOrder()
        {
            var order = await OrderService.CreateOrder(Products);
            return order;
        }

        [JSInvokable]
        public async Task<PaypalCapureComplete> CaptureOrder(string orderId)
        {
            var order = await OrderService.CaputreOrder(orderId);
            productKeys = order.Keys;
            paypalCapure = order.CompleteCaputre;
            return order.CompleteCaputre;
        }

        [JSInvokable]
        public void OrderCompleted()
        {
            OrderIsComplete = true;
            CartService.EmptyCart();
        }

        public void Dispose()
        {
            objRef?.Dispose();
        }
    }
}
