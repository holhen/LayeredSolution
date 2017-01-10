using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.Components.DictionaryAdapter;
using FluentAssertions;
using LayeredSolution.BusinessLayer;
using LayeredSolution.DataLayer;
using LayeredSolution.DataLayer.Schema;
using Moq;
using NUnit.Framework;

namespace LayeredSolution.Tests
{
    [TestFixture]
    class ProductsServ_iceTests
    {
        List<Product> productList;
        Mock<ISampleContext> sampleContextMock;
        [SetUp]
        public void TestElottiBeallitasok()
        {
            //Arrange
            productList = new List<Product>
            {
                new Product {Id = 1, Name = "alma", ProductNo = "123", Price = 10 },
                new Product {Id = 2, Name = "korte", ProductNo = "124", Price = 30 },
                new Product {Id = 3, Name = "barack", ProductNo = "231", Price = 20 },
            };
            sampleContextMock = new Mock<ISampleContext>();
            var productsDbSetMock = new Mock<DbSet<Product>>();
            productsDbSetMock.SetDataSource(productList);
            //Megadjuk, hogy a Products property térjen vissza a 
            // productsDbSetMock-al.
            sampleContextMock
                .Setup(sampleContext => sampleContext.Products)
                .Returns(productsDbSetMock.Object);
        }

        [TearDown]
        public void LefutMindenTTesztUtan()
        {
            
        }
        [Test]
        public void GetAllProduct_OnEmptySearchString_ShouldReturnAllTheProducts()
        {
            ISampleContext context = sampleContextMock.Object;
            ProductService objectUnderTest = new ProductService(context);
            //Act
            var result = objectUnderTest.GetAllProduct("");
            //Assert
            result.Should().NotBeNull();
            result.Count.Should().Be(productList.Count);
        }

        [Test]
        public void GetAllProduct_OnSearchString12_ShouldFilterProductNOField()
        {
            ISampleContext context = sampleContextMock.Object;
            ProductService objectUnderTest = new ProductService(context);
            //Act
            var result = objectUnderTest.GetAllProduct("12");
            //Assert
            result.Should().NotBeNull();
            //A listának tartalmaznia kell elemet.
            result.Count.Should().BeGreaterThan(0);
            //A listának csak olyan elemeket kell tartalmaznia, aminek a cikkszámában szerepel 12
            result.Should().OnlyContain(product => product.ProductNo.Contains("12"));

        }
    }
}
