using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using LayeredSolution.DataLayer.Schema;
using Castle.Components.DictionaryAdapter;
using LayeredSolution.DataLayer;
using LayeredSolution.BusinessLayer;
using FluentAssertions;
using Moq;
using System.Data.Entity;

namespace LayeredSolution.Test
{
    [TestFixture]
    class ProductService_Test
    {
        List<Product> productList;
        Mock<ISampleContext> sampleContextMock;
        [SetUp]
        public void TestElottiBeallitasok()
        {
            productList = new EditableList<Product>
            {
            new Product { Id = 1, Name = "alma", ProductNo = "123", Price = 10 },
            new Product { Id = 2, Name = "körte", ProductNo = "231", Price = 30},
            new Product { Id = 3, Name = "barack", ProductNo = "124", Price = 20 }
            };
            sampleContextMock = new Mock<ISampleContext>();
            var productsDbSetMock = new Mock<DbSet<Product>>();
            productsDbSetMock.SetDataSource(productList);
            sampleContextMock.SetupGet(sampleContext => sampleContext.Products).Returns(productsDbSetMock.Object);
        } 
        [Test]
        public void GetAllProduct_OnEmptySearchString()
        {
            ISampleContext context = sampleContextMock.Object;
            ProductService objectUnderTest = new ProductService(context);
            var result = objectUnderTest.GetAllProduct("");
            result.Should().NotBeNull();
            result.Count().Should().Be(productList.Count());
                
        }
        [Test]
        public void GetAllProducts_OnSearchString12_ShouldFilterProductNOField()
        {
            ISampleContext context = sampleContextMock.Object;
            ProductService objectUnderTest = new ProductService(context);
            var result = objectUnderTest.GetAllProduct("12");
            result.Should().NotBeNull();
            result.Count().Should().BeGreaterThan(0);
            result.Should().OnlyContain(product => product.ProductNo.Contains("12"));
        }
        public void GetAllProducts_OnSearchString_ShouldFilterNameField()
        {
            ISampleContext context = sampleContextMock.Object;
            ProductService objectUnderTest = new ProductService(context);
            var result = objectUnderTest.GetAllProduct("phone");
            result.Should().NotBeNull();
            result.Count().Should().BeGreaterThan(0);
            result.Should().OnlyContain(product => product.Name.Contains("phone"));
        }

    }
}
