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
        IProductService ProductService { get; set; }
        [Inject]
        IGenreService GenreService { get; set; }
        [Inject]
        ICartService CartService { get; set; }

        [Inject]
        NavigationManager navigation { get; set; }

        PagedList<ProductDTO> Products;

        List<GenreDTO> Genres;

        protected override async Task OnInitializedAsync()
        {
            var pagination = new Pagination(40);
            Genres = await GenreService.GetAllGenres();
            Products = await ProductService.GetProducts(pagination);
        }

        async Task reloadProducts()
        {
            Products = await ProductService.GetProducts(Products.Paging);
            StateHasChanged();
            navigation.NavigateTo(navigation.BaseUri);
        }


        async Task OnPage(MatPaginatorPageEvent e)
        {
            Products.Paging.CurrentPage = e.PageIndex + 1;
            await reloadProducts();
        }

        void ResetFilter()
        {
            Products.Paging.Search = null;
            Products.Paging.MaxPrice = 0;
            Products.Paging.IsOnSale = false;
            Products.Paging.GenreId = 0;
        }

    }
}
