using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LayeredSolution.Szamlazo.EmployeeViews
{
    public partial class LoginForm : Form
    {
        private readonly LoginViewModel _loginViewModel;

        public LoginForm(LoginViewModel loginViewModel)
        {
            _loginViewModel = loginViewModel;
            InitializeComponent();
            loginBindingSource.DataSource = _loginViewModel;
        }

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.OK)
            {
                _loginViewModel.Login(e);
            }
        }
    }
}
