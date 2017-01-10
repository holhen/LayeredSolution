using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LayeredSolution.BusinessLayer.Common;
using LayeredSolution.BusinessLayer.EmployeeModels;

namespace LayeredSolution.Szamlazo.EmployeeViews
{
    public class EmployeeEditViewModel : BaseModel
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeEditViewModel(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        
        public EmployeeModel Employee { get; private set; }

        public void EditEmployee(EmployeeModel model)
        {
            Employee = model ?? new EmployeeModel();
            OnPropertyChanged(nameof(Employee));
        }

        public void SaveEmployee()
        {
            _employeeService.SaveEmployee(Employee);
        }
    }
}
