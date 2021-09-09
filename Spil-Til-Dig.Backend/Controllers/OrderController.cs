using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Spil_Til_Dig.Backend.Services;
using Spil_Til_Dig.Shared.Entities;
using Spil_Til_Dig.Shared.Helpers;
using Spil_Til_Dig.Shared.Models;
using Spil_Til_Dig.Shared.Models.DTO;
using Spil_Til_Dig.Shared.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spil_Til_Dig.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrderController : ControllerBase
    {
        private readonly IPayPalService payPalService;
        protected readonly IMapper mapper;
        private readonly IUserService userService;
        public OrderController(IPayPalService payPalService, IMapper mapper, IUserService userService)
        {
            this.payPalService = payPalService;
            this.mapper = mapper;
            this.userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetOrderHistory([FromQuery] Pagination pagination)
        {
            if (pagination == null)
            {
                pagination = new Pagination();
            }

            var list = await userService.GetPagedOrderHistory(User.GetUserId() ,pagination);
            var dest = mapper.Map<PagedList<Order>, PagedList<OrderDTO>>(list);
            dest.Paging = list.Paging;
            return Ok(dest);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderDTO createOrder)
        {
            var result = await payPalService.CreateOrder(mapper.Map<List<Product>>(createOrder.Products), User.GetUserId());
            return Ok(result);
        }

        [HttpPost("capture/{orderNumber}")]
        public async Task<IActionResult> CaptureOrder(string orderNumber)
        {
            var result = await payPalService.CaptureOrder(orderNumber);
            return Ok(result);
        }

        [HttpDelete("DeleteAllUserData")]
        public async Task<IActionResult> DeleteAllUserData()
        {
            await userService.DeleteAllUserData(User.GetUserId());
            return Ok();
        }
    }
}
