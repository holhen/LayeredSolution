using LayeredSolution.BusinessLayer.Common;
using LayeredSolution.BusinessLayer.EmployeeModels;
using LayeredSolution.Szamlazo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayeredSolution.BusinessLayer.EmployeeViews
{
    public class LoginViewModel : BaseModel
    {
        private string _userName;
        private string _password;
        private IMessageService _messageService;
        private ILoggedInEmployeeService _loggedInEmployeeService;
        private IEmployeeService _employeeService;

        public LoginViewModel(IMessageService messageService, ILoggedInEmployeeService loggedInEmployeeService, IEmployeeService employeeService)
        {
            _messageService = messageService;
            _loggedInEmployeeService = loggedInEmployeeService;
            _employeeService = employeeService;
        }
        public string UserName
        {
            get { return _userName; }
            set
            {
                OnPropertyChanged(ref _userName, value);
            }
        }
        public string Password
        {
            get { return _password; }
            set { OnPropertyChanged(ref _password, value); }
        }
        public void Login(CancelEventArgs cea)
        {
            EmployeeModel employeeModel = _employeeService.Login(UserName, Password);
            if (employeeModel != null)
            {
                _loggedInEmployeeService.LoggedInEmployee = employeeModel;
                return;
            }
            else
            {
                _messageService.ShowErrorMessage("Hibás felhasználónév vagy jelszó.");
                cea.Cancel = true;
            }
        }
    }
}
