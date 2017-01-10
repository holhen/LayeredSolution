using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayeredSolution.BusinessLayer.EmployeeModels
{
    public interface ILoggedInEmployeeService
    {
        EmployeeModel LoggedInEmployee { get; set; }

        bool IsInRole(string role);
    }
}
