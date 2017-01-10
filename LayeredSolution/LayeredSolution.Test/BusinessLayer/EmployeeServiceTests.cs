using FluentAssertions;
using LayeredSolution.BusinessLayer.Common;
using LayeredSolution.BusinessLayer.EmployeeModels;
using LayeredSolution.DataLayer;
using LayeredSolution.DataLayer.Schema;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayeredSolution.Test.BusinessLayer
{
    [TestFixture]
    public class EmployeeServiceTests
    {
        private EmployeeService _employeeService;
        private Mock<ISampleContext> _sampleContext;
        private Mock<DbSet<EmployeeEntity>> _employeeDbSetMock;

        [SetUp]
        public void Setup()
        {
            _sampleContext = new Mock<ISampleContext>();
            _employeeDbSetMock = new Mock<DbSet<EmployeeEntity>>();
            _sampleContext.SetupGet(context => context.Employees).Returns(_employeeDbSetMock.Object);
            var employees = new List<EmployeeEntity>();
            employees.Add(new EmployeeEntity
            {
                Id = 1,
                UserName = "correct",
                Password = PasswordHelper.EncryptPassword("correct password")
            });
            _employeeDbSetMock.SetDataSource(employees);
            _employeeService = new EmployeeService(_sampleContext.Object);
        }
        [Test]
        public void Login_OnCorrectUserAndPassword_ShouldReturnEmployeeModel()
        {
            //Arrange
            //Act
            var result = _employeeService.Login("correct", "correct password");
            //Assert
            result.Should().NotBeNull();
            result.Id.Should().Be(1);

        }
    }
}
