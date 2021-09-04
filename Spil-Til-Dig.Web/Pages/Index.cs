using MatBlazor;
using Microsoft.AspNetCore.Components;
using Spil_Til_Dig.Shared.Models;
using Spil_Til_Dig.Shared.Models.DTO;
using Spil_Til_Dig.Shared.Wrappers;
using Spil_Til_Dig.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spil_Til_Dig.Web.Pages
{
    public partial class Index
    {
        [Inject]
        IProductService productService { get; set; }

        [Inject]
        NavigationManager navigation { get; set; }

        PagedList<ProductDTO> Products;

        protected override async Task OnInitializedAsync()
        {
            var pagination = new Pagination(60);
            Products = await productService.GetProducts(pagination);
        }

        async Task reloadProducts()
        {
            Products = await productService.GetProducts(Products.Paging);
            StateHasChanged();
            navigation.NavigateTo(navigation.BaseUri);
        }


        async Task OnPage(MatPaginatorPageEvent e)
        {
            Products.Paging.CurrentPage = e.PageIndex + 1;
            await reloadProducts();
        }
    }
}
