using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using LayeredSolution.BusinessLayer.EmployeeModels;
using LayeredSolution.Szamlazo;
using LayeredSolution.Szamlazo.EmployeeViews;
using Moq;
using NUnit.Framework;

namespace LayeredSolution.Tests.ViewModels
{
    [TestFixture]
    public class LoginViewModelTests
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
                employeeServiceMock.Object);
        }
        [Test]
        public void Login_OnCorrectUserAndPassword_ShouldSetTheLoggedInUser()
        {
            //Arrange
            var correctUser = "correct user";
            var correctPassword = "correct password";
            var cancelEventArgs = new CancelEventArgs();
            var employee = new EmployeeModel();
            employeeServiceMock.Setup(service =>
                service.Login(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(employee);
            //Act
            _viewModel.UserName = correctUser;
            _viewModel.Password = correctPassword;
            _viewModel.Login(cancelEventArgs);
            //Assert
            cancelEventArgs.Cancel.Should().BeFalse("Sikeresen bejelntekzünk");
            loggedInEmployeeServiceMock.Object.LoggedInEmployee
                .Should().NotBeNull("a login kitölti");
            //Ellenorzi, hogy a Login metodus meg lett-e hivva pontosan egyszer.
            employeeServiceMock.Verify(service => 
            service.Login(It.IsAny<string>(), It.IsAny<string>()), 
            Times.Once);
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
            cancelEventArgs.Cancel.Should().BeTrue("Hibás felhasználónál nem lépünk be.");
            messageServiceMock.Verify(service => service.ShowErrorMessage(It.IsAny<string>())
                ,Times.Once);
        }
    }
}
