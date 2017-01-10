using LayeredSolution.BusinessLayer;
using LayeredSolution.Szamlazo.OrderViews;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LayeredSolution.Szamlazo
{
    public partial class NewItemForm : Form
    {
        private NewItemViewModel _viewModel;
        private string _productName;
        private int _price;
        public NewItemForm(NewItemViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
        }

        private void NewItemForm_Load(object sender, EventArgs e)
        {
            bindingSource1.DataSource = _viewModel.Orders;
        }

        private void productNoBox_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                ValidateProductNo();
            }
        }
        private void NewItemForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                if (_viewModel.RecordOrder(name.Text, address.Text, email.Text))
                    Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (_viewModel.RecordOrder(name.Text, address.Text, email.Text))
                Close();
        }

        private void quantityNumber_Validated(object sender, EventArgs e)
        {
            double sum;
            if (quantityNumber.Value == 0)
            {
                MessageBox.Show("A mennyiségnek nagyobbnak kell lennie, mint 0!");
                quantityNumber.Focus();
                quantityNumber.Select(0, quantityNumber.Text.Length);
            }
            else if (string.IsNullOrWhiteSpace(productNoBox.Text))
            {
                MessageBox.Show("Írjon be egy cikkszámot!");
                productNoBox.Focus();
                productNoBox.SelectAll();
            }
            else
            {
                _viewModel.RegisterToDatabase(productNoBox.Text, _productName, _price, quantityNumber.Value, out sum);
                quantityBox.Text = quantityNumber.Value.ToString();
                total.Text = sum.ToString();
            }
        }

        private void productNoBox_Validated(object sender, EventArgs e)
        {
            ValidateProductNo();
        }

        private void ValidateProductNo()
        {
            if (_viewModel.AddOrderItemToTable(productNoBox.Text, out _productName, out _price))
            {
                productNameLabel.Text = _productName;
                priceLabel.Text = _price.ToString();
                quantityNumber.Focus();
                quantityNumber.Select(0, quantityNumber.Text.Length);
            }
            else
            {
                MessageBox.Show("A megadott cikkszámú áru nem létezik!");
                productNoBox.Focus();
                productNoBox.SelectAll();
            }
        }
    }
}
