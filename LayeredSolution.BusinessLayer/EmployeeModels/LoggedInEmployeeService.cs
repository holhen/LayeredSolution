using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayeredSolution.BusinessLayer.EmployeeModels
{
    public class LoggedInEmployeeService : ILoggedInEmployeeService
    {
        public EmployeeModel LoggedInEmployee { get; set; }

        public bool IsInRole(string role)
        {
            throw new NotImplementedException();
        }
    }
}
