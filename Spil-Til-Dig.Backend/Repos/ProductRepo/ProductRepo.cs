using Microsoft.EntityFrameworkCore;
using Spil_Til_Dig.Backend.Database;
using Spil_Til_Dig.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spil_Til_Dig.Backend.Repos
{
    public class ProductRepo : Repo<Product, long>, IProductRepo
    {
        public ProductRepo(DatabaseContext context) : base(context)
        {
        }

        public override IQueryable<Product> GetAll()
        {
            return base.GetAll().Include(g => g.Genres);
        }

        public override async Task<Product> GetAsync(long Id)
        {
            return await _context.Products.Include(g => g.Genres).Include(k => k.Keys.Where(x => !x.IsSold)).FirstOrDefaultAsync(x => x.Id == Id);
        }
    }
}
