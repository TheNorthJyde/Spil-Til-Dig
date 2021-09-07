using Microsoft.AspNetCore.Components;
using Spil_Til_Dig.Shared.Models.DTO;
using Spil_Til_Dig.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spil_Til_Dig.Web.Components
{
    public partial class ShoppingCart : IDisposable
    {
        [Inject]
        ICartService CartService { get; set; }

        List<ProductDTO> Products = new List<ProductDTO>();

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            Products = await CartService.GetCart();
            StateHasChanged();
        }

        protected override void OnInitialized()
        {
            CartService.OnChange += StateHasChanged;
        }

        public void Dispose()
        {
            CartService.OnChange -= StateHasChanged;
        }

    }
}
