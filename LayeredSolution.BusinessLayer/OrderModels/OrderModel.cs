using System.Collections.Generic;
using System.Linq;

namespace LayeredSolution.BusinessLayer
{
    public class OrderModel
    {
        public virtual int Id { get; set; }
        public virtual string BuyerName { get; set; }
        public virtual string BuyerEmail { get; set; }
        public virtual string BuyerAddress { get; set; }
        public double Summary { get { if (OrderItems == null) return 0;  return OrderItems.Sum(e => e.Price * e.Quantity); } }
        public double Count { get { if (OrderItems == null) return 0; return OrderItems.Sum(e => e.Quantity); } }
        public virtual List<OrderItemModel> OrderItems { get; set; }
    }
}