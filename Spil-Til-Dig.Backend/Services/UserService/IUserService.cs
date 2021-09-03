using Spil_Til_Dig.Shared.Entities;
using Spil_Til_Dig.Shared.Models;
using Spil_Til_Dig.Shared.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spil_Til_Dig.Backend.Services
{
    public interface IUserService
    {
        Task<PagedList<Order>> GetPagedOrderHistory(string userId, Pagination pagination);
        Task<Order> GetOrder(string orderId);
        Task DeleteAllUserData(string userId);
    }
}
