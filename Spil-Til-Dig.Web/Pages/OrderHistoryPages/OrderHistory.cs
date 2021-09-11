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

namespace Spil_Til_Dig.Web.Pages.OrderHistoryPages
{
    public partial class OrderHistory
    {
        [Inject]
        IOrderService OrderService { get; set; }
        [Inject]
        NavigationManager navigation { get; set; }

        PagedList<OrderDTO> Orders;

        protected override async Task OnInitializedAsync()
        {
            var pagination = new Pagination(20);
            Orders = await OrderService.GetOrders(pagination);
        }

        async Task reloadOrders()
        {
            Orders = await OrderService.GetOrders(Orders.Paging);
            StateHasChanged();
            navigation.NavigateTo(navigation.BaseUri);
        }

        async Task OnPage(MatPaginatorPageEvent e)
        {
            Orders.Paging.CurrentPage = e.PageIndex + 1;
            await reloadOrders();
        }
    }
}
