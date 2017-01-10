using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FizzWare.NBuilder;
using FluentAssertions;
using LayeredSolution.BusinessLayer.EmployeeModels;
using LayeredSolution.Szamlazo.EmployeeViews;
using Moq;
using NUnit.Framework;

namespace LayeredSolution.Tests.ViewModels
{
    [TestFixture]
    public class EmployeeListViewModelTests
    {
        private EmployeeListViewModel _employeeListViewModel;
        private Mock<IEmployeeService> _employeeServiceMock;
        private List<EmployeeModel> employees;
        [SetUp]
        public void Setup()
        {
            _employeeServiceMock = new Mock<IEmployeeService>();
            employees = Builder<EmployeeModel>.CreateListOfSize(10)
                .Build()
                .ToList();
            _employeeServiceMock.Setup(service => service.GetEmployees()).Returns(employees);
            _employeeListViewModel = new EmployeeListViewModel(_employeeServiceMock.Object);
        }

        [Test]
        public void OnLoad_WhenEmployeesInTheDatabase_ShouldReturnAllElement()
        {
            //Act
            _employeeListViewModel.LoadEmployees();
            //Assert
            _employeeListViewModel.Employees.Should().NotBeNull();
            _employeeListViewModel.Employees.Should().HaveCount(employees.Count);
        }

        [Test]
        public void SearchText_WhenChanged_ShouldFilterTheEmploeesBindingList()
        {
            var searchText = "name2";
            //Act
            _employeeListViewModel.LoadEmployees();
            _employeeListViewModel.SearchText = searchText;
            //Assert
            _employeeListViewModel.Employees.Count.Should().BeGreaterThan(0);
            _employeeListViewModel.Employees.Should()
                .OnlyContain(model => model.Name.ToLower().Contains(searchText));
            _employeeListViewModel.Employees.Should().OnlyHaveUniqueItems();

        }
    }
}
