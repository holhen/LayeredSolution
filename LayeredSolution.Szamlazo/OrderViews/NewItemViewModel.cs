using LayeredSolution.BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LayeredSolution.Szamlazo.OrderViews
{
    public class NewItemViewModel
    {
        public BindingList<OrderItemModel> Orders = new BindingList<OrderItemModel>();
        private IProductService _productService;
        private IOrderService _orderService;
        public NewItemViewModel(IProductService productService, IOrderService orderService)
        {
            _productService = productService;
            _orderService = orderService;
        }

        public bool AddOrderItemToTable(string search, out string productName, out int price)
        {
            List<ProductModel> products = _productService.GetAllProduct(search);
            if (products.Any())
            {
                productName = products.Select(entry => entry.Name).First();
                price = products.Select(entry => entry.Price).First();
                return true;
            }
            else
            {
                productName = null;
                price = 0;
                return false;
            }
        }

        public void RegisterToDatabase(string productNo, string productName, int price, decimal quantity, out double total)
        {
            OrderItemModel orderItem = new OrderItemModel
            {
                ProductId = _productService.GetAllProduct(productNo).Where(entry => entry.Name == productName).Select(entry => entry.Id).FirstOrDefault(),
                ProductNo = productNo,
                ProductName = productName,
                Price = price,
                Quantity = (int)quantity
            };
            Orders.Add(orderItem);
            total = Orders.Sum(entry => entry.SumItem);
        }

        public bool RecordOrder(string customerName, string customerAddress, string customerEmail)
        {
            if (!Orders.Any() || string.IsNullOrEmpty(customerName) || string.IsNullOrEmpty(customerAddress) || string.IsNullOrEmpty(customerEmail))
            {
                MessageBox.Show("Rendeljen egy árut és töltsön ki minden mezőt!");
                return false;
            }
            else
            {
                _orderService.CreateOrder(new OrderModel
                {
                    BuyerName = customerName,
                    BuyerAddress = customerAddress,
                    BuyerEmail = customerEmail,
                    OrderItems = Orders.ToList()
                });
                return true;
            }
        }
    }
}
