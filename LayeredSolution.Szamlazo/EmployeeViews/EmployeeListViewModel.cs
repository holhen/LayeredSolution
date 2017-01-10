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
    public class EmployeeListViewModel : BaseModel
    {
        private readonly IEmployeeService _employeeService;
        private List<EmployeeModel> _allEmployees;
        private string _searchText;

        public EmployeeListViewModel(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
            Employees = new BindingList<EmployeeModel>();
        }

        public string SearchText
        {
            get { return _searchText; }
            set
            {
                if (OnPropertyChanged(ref _searchText, value))
                {
                    PerformSearch();
                }
            }
        }

        public BindingList<EmployeeModel> Employees { get; }

        public void LoadEmployees()
        {
            _allEmployees = _employeeService.GetEmployees();
            PerformSearch();
        }

        private void PerformSearch()
        {
            Employees.Clear();
            foreach (var employeeModel in _allEmployees
                .Where(e => e.Name != null && e.Name.ToLower().Contains(SearchText?.ToLower() ?? "")))
            {
                Employees.Add(employeeModel);
            }
        }
    }
}
