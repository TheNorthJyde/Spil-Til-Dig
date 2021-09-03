using Microsoft.EntityFrameworkCore;
using Spil_Til_Dig.Backend.Database;
using Spil_Til_Dig.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spil_Til_Dig.Backend.Repos
{
    public class OrderRepo : Repo<Order, string>, IOrderRepo
    {
        public OrderRepo(DatabaseContext context) : base(context)
        {
        }

        public override async Task<Order> GetAsync(string Id)
        {
            return await _context.Orders.Include(k => k.Keys).ThenInclude(p => p.Product).FirstOrDefaultAsync(x => x.Id == Id);
        }

        public override IQueryable<Order> GetAll()
        {
            return base.GetAll().Include(k => k.Keys).ThenInclude(p => p.Product);
        }

        
    }
}
