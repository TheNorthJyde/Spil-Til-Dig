using Microsoft.AspNetCore.Components;
using Spil_Til_Dig.Shared.Models.DTO;
using Spil_Til_Dig.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spil_Til_Dig.Web.Pages.GameInfoPage
{
    public partial class GameInfo
    {
        [Parameter]
        public long GameId { get; set; }

        [Inject]
        ICartService CartService { get; set; }
        [Inject]
        IProductService ProductService { get; set; }

        ProductDTO Product;

        protected override async Task OnInitializedAsync()
        {
            Product = await ProductService.GetProduct(GameId);
        }


    }
}
