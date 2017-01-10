using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LayeredSolution.BusinessLayer.Common;
using LayeredSolution.BusinessLayer.EmployeeModels;

namespace LayeredSolution.Szamlazo.EmployeeViews
{
    public class LoginViewModel : BaseModel
    {
        private readonly IMessageService _messageService;
        private readonly ILoggedInEmployeeService _loggedInEmployeeService;
        private readonly IEmployeeService _employeeService;
        private string _userName;
        private string _password;

        public LoginViewModel(IMessageService messageService,
            ILoggedInEmployeeService loggedInEmployeeService, 
            IEmployeeService employeeService)
        {
            _messageService = messageService;
            _loggedInEmployeeService = loggedInEmployeeService;
            _employeeService = employeeService;
        }

        public string UserName
        {
            get { return _userName; }
            set { OnPropertyChanged(ref _userName, value); }
        }
        public string Password
        {
            get { return _password; }
            set { OnPropertyChanged(ref _password, value); }
        }

        public void Login(CancelEventArgs args)
        {
            EmployeeModel employeeModel = _employeeService.Login(UserName, Password);
            if (employeeModel != null)
            {
                _loggedInEmployeeService.LoggedInEmployee = employeeModel;
            }
            else
            {
                _messageService.ShowErrorMessage("Hibás felhasználónév, vagy jelszó.");
                args.Cancel = true;
            }
        }
    }
}
