using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LayeredSolution.BusinessLayer.EmployeeModels;

namespace LayeredSolution.Szamlazo.EmployeeViews
{
    public partial class EmployeeEditForm : Form
    {
        private readonly EmployeeEditViewModel _employeeEditModel;
        public EmployeeEditForm(EmployeeEditViewModel employeeEditViewModel)
        {
            _employeeEditModel = employeeEditViewModel;
            InitializeComponent();
        }

        public void EditModel(EmployeeModel employeeModel)
        {
            _employeeEditModel.EditEmployee(employeeModel);
            employeeModelBindingSource.DataSource = _employeeEditModel.Employee;
        }

        private void EmployeeEditForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.OK)
            {
                _employeeEditModel.SaveEmployee();
            }
        }
    }
}
