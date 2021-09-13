using Moq;
using NUnit.Framework;
using Spil_Til_Dig.Shared.Entities;
using Spil_Til_Dig.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spil_Til_Dig.Test.ProductTest
{
    [TestFixture]
    public class ProductServiceTest : ProductTest
    {
        [Test]
        public async Task Create()
        {
            await productService.AddProductsFromCMS(Seed(2));
            productRepoMock.Verify(x => x.AddRangeAsync(It.IsAny<List<Product>>()), Times.Once);
            productRepoMock.Verify(x => x.SaveAsync(), Times.Once);
        }

        [Test]
        public async Task Delete()
        {
            await productService.DeleteProductFromCMS(1);
            productRepoMock.Verify(x => x.Remove(It.IsAny<Product>()), Times.Once);
            productRepoMock.Verify(x => x.SaveAsync(), Times.Once);
        }

        [Test]
        public async Task GetList()
        {
            var products = await productService.GetPagedProducts(new Pagination(10));
            
            productRepoMock.Verify(x => x.GetAll(), Times.Once);
            Assert.AreEqual(products.Count, 10);
        }
    }
}
