using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using Spil_Til_Dig.Backend.Repos;
using Spil_Til_Dig.Backend.Services;
using Spil_Til_Dig.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Spil_Til_Dig.Test.ProductTest
{
    public abstract class ProductTest
    {
        public Mock<IProductRepo> productRepoMock;

        public ProductService productService;
        private List<Product> Products;
        Random random = new();

        [SetUp]
        public void Setup()
        {
            Products = Seed();
            productRepoMock = new();
            productRepoMock.Setup(x => x.AddRangeAsync(It.IsAny<List<Product>>()));
            productRepoMock.Setup(x => x.SaveAsync());
            productRepoMock.Setup(x => x.Remove(It.IsAny<Product>()));
            productRepoMock.Setup(x => x.FindAsync(It.IsAny<Expression<Func<Product, bool>>>())).ReturnsAsync(mockProduct(1));
            productRepoMock.Setup(x => x.GetAll()).Returns(mockQueryableProducts());
            productService = new(productRepoMock.Object);

        }

        public List<Product> Seed(int amount = 10)
        {
            var list = new List<Product>();
            
            
            for (long i = 0; i < amount; i++)
            {
                
                list.Add(mockProduct(i));
            }
            return list;
           
        }

        private IQueryable<Product> mockQueryableProducts()
        {
            var data = Products.AsQueryable();
            var mockset = new Mock<IQueryable<Product>>();
            mockset.As<IAsyncEnumerable<Product>>().Setup(x => x.GetAsyncEnumerator(It.IsAny< CancellationToken>())).Returns(new TestAsyncEnumerator<Product>(data.GetEnumerator()));
            mockset.As<IQueryable<Product>>().Setup(x => x.Provider).Returns(new TestAsyncQueryProvider<Product>(data.Provider));

            mockset.As<IQueryable<Product>>().Setup(x => x.Expression).Returns(data.Expression);
            mockset.As<IQueryable<Product>>().Setup(x => x.ElementType).Returns(data.ElementType);
            mockset.As<IQueryable<Product>>().Setup(x => x.GetEnumerator()).Returns(() => data.GetEnumerator());
            return mockset.Object;
        }

        public Product mockProduct(long id)
        {
            var product = new Product();
            product.Genres = new List<Genre>();
            product.Keys = new List<ProduktKey>();
            product.Id = id;
            product.Name = randomstring();
            product.Publicher = randomstring();
            product.Developer = randomstring();
            for (int n = 0; n < random.Next(1, 5); n++)
            {
                product.Genres.Add(new Genre
                {
                    Id = id,
                    Name = randomstring()
                });
            }
            product.ImageUrl = "https:test.com/img/" + id + ".jpg";
            product.Price = random.Next(15, 400);
            product.ReleaseDate = RandomDay();
            product.Summary = $"{randomstring()} {randomstring()} {randomstring()} {randomstring()} {randomstring()} {randomstring()} {randomstring()} {randomstring()} {randomstring()} {randomstring()} {randomstring()} {randomstring()} ";
            var ProduktKeyAmount = random.Next(5, 50);
            for (int n = 0; n < ProduktKeyAmount; n++)
            {
                product.Keys.Add(new ProduktKey(Guid.NewGuid().ToString()));
            }
            return product;
        }

        private string randomstring()
        {
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, random.Next(5, 15))
      .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        private DateTime RandomDay()
        {
            DateTime start = new(2000, 1, 1);
            int range = (DateTime.Today - start).Days;
            return start.AddDays(random.Next(range));
        }

    }
}
