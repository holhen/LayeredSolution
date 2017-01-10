using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayeredSolution.BusinessLayer
{
    public interface IOrderService
    {
        List<OrderModel> GetOrders();
        void CreateOrder(OrderModel orderModel);
    }
}
