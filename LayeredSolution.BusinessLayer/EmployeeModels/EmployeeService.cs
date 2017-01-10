using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LayeredSolution.BusinessLayer.Common;
using LayeredSolution.DataLayer;
using LayeredSolution.DataLayer.Schema;

namespace LayeredSolution.BusinessLayer.EmployeeModels
{
    public class EmployeeService : IEmployeeService
    {
        private readonly ISampleContext _sampleContext;

        public EmployeeService(ISampleContext sampleContext)
        {
            _sampleContext = sampleContext;
        }

        public EmployeeModel Login(string userName, string password)
        {
            var employeeModel = _sampleContext.Employees
                .Where(e => e.UserName == userName)
                .Select(e => new EmployeeModel
                {
                    Id = e.Id,
                    Name = e.Name,
                    Password = e.Password,
                    UserName = e.UserName,
                    Role = e.Role,
                    Position = e.Position
                })
                .FirstOrDefault();
            if (employeeModel == null) return null;
            if (PasswordHelper.CheckPassword(password, employeeModel.Password))
            {
                return employeeModel;
            }
            return null;
        }
        
        public List<EmployeeModel> GetEmployees()
        {
            return _sampleContext.Employees.Select(e => new EmployeeModel
            {
                Id = e.Id,
                Name = e.Name,
                UserName = e.UserName,
                Role = e.Role,
                Position = e.Position
            }).ToList();
        }

        public void SaveEmployee(EmployeeModel employee)
        {
            EmployeeEntity employeeEntity;
            if (employee.Id > 0)
            {
                employeeEntity = _sampleContext.Employees
                    .Where(e => e.Id == employee.Id)
                    .FirstOrDefault();
            }
            else
            {
                employeeEntity = new EmployeeEntity();
                _sampleContext.Employees.Add(employeeEntity);
            }
            employeeEntity.Name = employee.Name;
            employeeEntity.Position = employee.Position;
            employeeEntity.Role = employee.Role;
            employeeEntity.UserName = employee.UserName;
            if (!string.IsNullOrEmpty(employee.Password))
            {
                employeeEntity.Password = PasswordHelper.EncryptPassword(employee.Password);
            }
            _sampleContext.SaveChanges();
        }
    }
}
