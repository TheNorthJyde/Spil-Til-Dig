using Microsoft.EntityFrameworkCore;
using Spil_Til_Dig.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spil_Til_Dig.Backend.Database
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<ProduktKey> Keys { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Product>().Property(x => x.Id).ValueGeneratedNever();
            builder.Entity<Genre>().Property(x => x.Id).ValueGeneratedNever();
            builder.Entity<ProduktKey>().Property(x => x.Id).ValueGeneratedNever();
            builder.Entity<Order>().Property(x => x.Id).ValueGeneratedNever();
        }
    }
}
