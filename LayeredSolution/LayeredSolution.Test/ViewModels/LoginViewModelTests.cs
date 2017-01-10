using LayeredSolution.BusinessLayer.EmployeeModels;
using LayeredSolution.BusinessLayer.EmployeeViews;
using LayeredSolution.Szamlazo;
using Moq;
using NUnit.Framework;
using System.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;

namespace LayeredSolution.Test.ViewModels
{
    [TestFixture]
    class LoginViewModelTests
    {
        private LoginViewModel _viewModel;
        private Mock<IMessageService> messageServiceMock;
        private Mock<ILoggedInEmployeeService> loggedInEmployeeServiceMock;
        private Mock<IEmployeeService> employeeServiceMock;
        [SetUp]
        public void Setup()
        {
            messageServiceMock = new Mock<IMessageService>();
            loggedInEmployeeServiceMock = new Mock<ILoggedInEmployeeService>();
            loggedInEmployeeServiceMock.SetupAllProperties();
            employeeServiceMock = new Mock<IEmployeeService>();
            _viewModel = new LoginViewModel(
                messageServiceMock.Object,
                loggedInEmployeeServiceMock.Object,
                employeeServiceMock.Object
           );
        }
        [Test]
        public void Login_OnCorrectUserAndPassword_ShouldSetTheLoggedInUser()
        {
            //Arrange
            string CorrectUser = "Correct User";
            string CorrectPassword = "Correct Password";
            var CancelEventArgs = new CancelEventArgs();
            var employee = new EmployeeModel();
            employeeServiceMock.Setup(service =>
            service.Login(It.IsAny<string>(), It.IsAny<string>())).Returns(employee);
            //Act
            _viewModel.UserName = CorrectUser;
            _viewModel.Password = CorrectPassword;
            _viewModel.Login(CancelEventArgs);
            //Assert
            CancelEventArgs.Cancel.Should().BeFalse("Sikeresen bejelentkezik");
            loggedInEmployeeServiceMock.Object.LoggedInEmployee.Should().NotBeNull("a login kitölti");
            employeeServiceMock.Verify(service => service.Login(It.IsAny<string>(), It.IsAny<string>()), Times.Once);
        }

        [Test]
        public void Login_OnWrongUserNameAndPassword_ShouldShowErrorAndCancel()
        {
            //Arrange
            var wrongUser = "user";
            var wrongPassword = "password";
            var cancelEventArgs = new CancelEventArgs();
            //Act
            _viewModel.UserName = wrongUser;
            _viewModel.Password = wrongPassword;
            _viewModel.Login(cancelEventArgs);
            //Assert
            cancelEventArgs.Cancel.Should().BeTrue("Hibás felhasználóval léptünk be.");
            messageServiceMock.Verify(service => service.ShowErrorMessage(It.IsAny<string>()));
        }
    }
}
