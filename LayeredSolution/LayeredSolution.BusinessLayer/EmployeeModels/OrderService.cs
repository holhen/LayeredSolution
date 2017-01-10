using System.Collections.Generic;
using System.Linq;
using LayeredSolution.DataLayer;
using LayeredSolution.DataLayer.Schema;

namespace LayeredSolution.BusinessLayer
{
    public class OrderService : BaseService, IOrderService
    {
        public OrderService(ISampleContext context) : base(context)
        {
            
        }
        public List<OrderModel> GetOrders()
        {
            var ordersForUser = Context.Orders
                .Select(e => new OrderModel
                {
                    Id = e.Id,
                    BuyerAddress = e.BuyerAddress,
                    BuyerEmail = e.BuyerEmail,
                    BuyerName = e.BuyerName,
                    OrderItems = e.OrderItems.Select(item => new OrderItemModel
                    {
                        Id = item.Id,
                        Price = item.Price,
                        OrderId = item.OrderId,
                        ProductId = item.ProductId,
                        Quantity = item.Quantity
                    }).ToList()
                }).ToList();
            return ordersForUser;
        }

        public void CreateOrder(OrderModel orderModel)
        {
            var order = new Order
            {
                BuyerAddress = orderModel.BuyerAddress,
                BuyerEmail = orderModel.BuyerEmail,
                BuyerName = orderModel.BuyerName,
                OrderItems = orderModel.OrderItems.Select(item => new OrderItem
                {
                    Price = item.Price,
                    OrderId = item.OrderId,
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                }).ToList()
            };
            Context.Orders.Add(order);
            Context.SaveChanges();
        }
    }
}