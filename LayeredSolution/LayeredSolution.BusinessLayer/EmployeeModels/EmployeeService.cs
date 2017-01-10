using LayeredSolution.BusinessLayer.Common;
using LayeredSolution.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayeredSolution.BusinessLayer.EmployeeModels
{
    public class EmployeeService: IEmployeeService
    {
        private readonly ISampleContext _sampleContext;
        public EmployeeService(ISampleContext sampleContext)
        {
            _sampleContext = sampleContext;
        }

        public List<EmployeeModel> GetEmployees()
        {
            throw new NotImplementedException();
        }

        public bool IsInRole(EmployeeModel user, string Role)
        {
            throw new NotImplementedException();
        }

        public EmployeeModel Login(string userName, string password)
        {
            var employeeModel = _sampleContext.Employees.Where(e => e.UserName == userName)
                .Select(e => new EmployeeModel
                {
                    Id = e.Id,
                    Name = e.Name,
                    Password = e.Password,
                    UserName = e.UserName,
                    Role = e.Role,
                    Position = e.Position
                }).FirstOrDefault();
            if (employeeModel == null) return null;
            if (PasswordHelper.CheckPassword(password, employeeModel.Password))
            {
                return employeeModel;
            }
            return null;
        }

        public void SaveEmployee(EmployeeModel employee)
        {
            throw new NotImplementedException();
        }
    }
}
