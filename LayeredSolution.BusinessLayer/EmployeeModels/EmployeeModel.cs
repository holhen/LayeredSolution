using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LayeredSolution.BusinessLayer.Common;

namespace LayeredSolution.BusinessLayer.EmployeeModels
{
    public class EmployeeModel : BaseModel
    {
        private int _id;
        private string _name;
        private string _position;
        private string _userName;
        private string _password;
        private string _role;

        public int Id
        {
            get { return _id; }
            set { OnPropertyChanged(ref _id, value); }
        }

        public string Name
        {
            get { return _name; }
            set { OnPropertyChanged(ref _name, value); }
        }

        public string Position
        {
            get { return _position; }
            set { OnPropertyChanged(ref _position, value); }
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

        public string Role
        {
            get { return _role; }
            set { OnPropertyChanged(ref _role, value); }
        }
    }
}
