using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using LayeredSolution.BusinessLayer.Common;
using LayeredSolution.BusinessLayer.EmployeeModels;
using LayeredSolution.DataLayer;
using LayeredSolution.DataLayer.Schema;
using Moq;
using NUnit.Framework;

namespace LayeredSolution.Tests.BusinessLayer
{
    [TestFixture]
    public class EmployeeServiceTests
    {
        private EmployeeService _employeeService;
        private Mock<ISampleContext> _sampleContext;
        private Mock<DbSet<EmployeeEntity>> _employeeDbSetMock;
        private List<EmployeeEntity> employees;

        [SetUp]
        public void Setup()
        {
            _sampleContext = new Mock<ISampleContext>();
            _employeeDbSetMock = new Mock<DbSet<EmployeeEntity>>();
            _sampleContext.SetupGet(context => context.Employees)
                .Returns(_employeeDbSetMock.Object);
            employees = new List<EmployeeEntity>();
            employees.Add(new EmployeeEntity
            {
                Id = 1,
                UserName = "correct",
                Password = PasswordHelper.EncryptPassword("correct password"),
                Role = "admin"
            });
            employees.Add(new EmployeeEntity
            {
                Id = 2,
                UserName = "user2",
                Password = PasswordHelper.EncryptPassword("password2"),
                Role = "user"
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

        [Test]
        public void GetEmployees_EmployeesInDatabase_SholdReturnAllElement()
        {
            //Act
            var result = _employeeService.GetEmployees();
            //Assert
            result.Should().NotBeNull();
            result.Should().HaveCount(employees.Count);
            result.Should().OnlyContain(e => e.Password == null);
        }

        [Test]
        public void SaveEmployee_OnNewEmployee_SaveNewEmployee()
        {
            //Arrange
            var newEmployee = new EmployeeModel
            {
                Id = 0,
                Name = "Új dolgozó",
                Password = "titok",
                Role = "user",
                UserName = "Valaki",
                Position = "Dolgozó"
            };
            //Act
            _employeeService.SaveEmployee(newEmployee);
            //Assert
            _employeeDbSetMock.Verify(
                set => set.Add(It.IsAny<EmployeeEntity>())
                ,Times.Once
                );
            _sampleContext.Verify(
                context => context.SaveChanges(),
                Times.Once
                );
        }

        [Test]
        public void SaveEmployee_OnExistingEmployee_UpdateEmployee()
        {

            //Arrange
            var existingEmployee = new EmployeeModel
            {
                Id = 1,
                Name = "Új dolgozó",
                Password = "titok",
                Role = "user",
                UserName = "Valaki",
                Position = "Dolgozó"
            };
            //Act
            _employeeService.SaveEmployee(existingEmployee);
            //Assert
            _sampleContext.Verify(
                context => context.SaveChanges(),
                Times.Once
                );
            var employeeEntity = employees.Find(e => e.Id == 1);
            employeeEntity.Name
                .Should().Be(existingEmployee.Name);
            PasswordHelper.CheckPassword(existingEmployee.Password
                , employeeEntity.Password).Should().BeTrue();
            employeeEntity.Role
                .Should().Be(existingEmployee.Role);
            employeeEntity.UserName
                 .Should().Be(existingEmployee.UserName);
            employeeEntity.Position
                 .Should().Be(existingEmployee.Position);
        }

        [Test]
        public void SaveEmployee_OnEmptyPassword_DontUpdatePassword()
        {

            //Arrange
            var employeeEntity = employees.Find(e => e.Id == 1);
            var oldPasswordHash = employeeEntity.Password;
            var existingEmployee = new EmployeeModel
            {
                Id = 1,
                Name = "Új dolgozó",
                Role = "user",
                UserName = "Valaki",
                Position = "Dolgozó",
                Password = ""
            };
            //Act
            _employeeService.SaveEmployee(existingEmployee);
            //Assert
            _sampleContext.Verify(
                context => context.SaveChanges(),
                Times.Once
                );
            employeeEntity.Name
                .Should().Be(existingEmployee.Name);
            employeeEntity.Password.Should().Be(oldPasswordHash);
            employeeEntity.Role
                .Should().Be(existingEmployee.Role);
            employeeEntity.UserName
                 .Should().Be(existingEmployee.UserName);
            employeeEntity.Position
                 .Should().Be(existingEmployee.Position);
        }
    }
}
