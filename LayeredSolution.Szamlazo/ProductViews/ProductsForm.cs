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
using LayeredSolution.DataLayer.Schema;

namespace LayeredSolution.Szamlazo
{
    public partial class ProductsForm : Form
    {
        private readonly IProductService _productService;
        public ProductsForm(IProductService productService)
        {
            InitializeComponent();
            _productService = productService;
        }

        private void ProductsForm_Load(object sender, EventArgs e)
        {
            productModelBindingSource.DataSource = _productService.GetProductEditModel();
        }

        private void ProductsForm_FormClosed(object sender, FormClosedEventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _productService.SaveProduct();
        }
        
        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {
            productModelBindingSource.CancelEdit();
            var bindingList = 
             (BindingList<ProductModel>)productModelBindingSource
             .DataSource;
            bindingList.Clear();
            foreach (var productModel in 
             _productService.GetAllProduct(searchTextBox.Text))
            {
                bindingList.Add(productModel);
            }
        }
    }
}
