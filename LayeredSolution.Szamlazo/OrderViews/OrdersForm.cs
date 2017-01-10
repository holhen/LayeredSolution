using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LayeredSolution.BusinessLayer;
using Autofac;

namespace LayeredSolution.Szamlazo
{
    public partial class OrdersForm : Form
    {
        private readonly IOrderService _service;
        public OrdersForm(IOrderService orderService)
        {
            InitializeComponent();
            _service = orderService;
        }
        
        private void OrdersForm_Load(object sender, EventArgs e)
        {
            orderBindingSource.DataSource = _service.GetOrders();
        }

        private void OrdersForm_FormClosed(object sender, FormClosedEventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var lifetimeScope = Program.Container.BeginLifetimeScope();
            var newItem = lifetimeScope.Resolve<NewItemForm>();
            newItem.MdiParent = MdiParent;
            newItem.WindowState = FormWindowState.Maximized;
            newItem.Show();
        }
    }
}
