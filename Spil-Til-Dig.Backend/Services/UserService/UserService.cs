using Microsoft.EntityFrameworkCore;
using Spil_Til_Dig.Backend.Repos;
using Spil_Til_Dig.Shared.Entities;
using Spil_Til_Dig.Shared.Models;
using Spil_Til_Dig.Shared.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spil_Til_Dig.Backend.Services
{
    public class UserService : IUserService
    {
        private readonly IOrderRepo orderRepo;
        private readonly IKeyRepo keyRepo;

        public UserService(IOrderRepo orderRepo, IKeyRepo keyRepo)
        {
            this.orderRepo = orderRepo;
            this.keyRepo = keyRepo;
        }

        public async Task DeleteAllUserData(string userId)
        {
            var orders = await orderRepo.GetAll().Where(x => x.UserId == userId).ToListAsync();
            foreach (var order in orders)
            {
                keyRepo.RemoveRange(order.Keys);
            }
            orderRepo.RemoveRange(orders);
            await orderRepo.SaveAsync();
        }

        public async Task<Order> GetOrder(string orderId)
        {
            return await orderRepo.GetAsync(orderId);
        }

        public async Task<PagedList<Order>> GetPagedOrderHistory(string userId, Pagination pagination)
        {
            pagination.PreparePaging();
            var source = orderRepo.GetAll();
            source = source.Where(x => x.UserId == userId);

            return await PagedList<Order>.CreateAsync(source, pagination);
        }
    }
}
