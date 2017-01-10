using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayeredSolution.BusinessLayer.EmployeeModels
{
    public interface IEmployeeService
    {
        EmployeeModel Login(string userName, string password);
        List<EmployeeModel> GetEmployees();
        void SaveEmployee(EmployeeModel employee);
    }

}
