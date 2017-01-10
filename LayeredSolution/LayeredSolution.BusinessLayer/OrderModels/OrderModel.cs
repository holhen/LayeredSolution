using System.Collections.Generic;

namespace LayeredSolution.BusinessLayer
{
    public class OrderModel
    {
        public virtual int Id { get; set; }
        public virtual string BuyerName { get; set; }
        public virtual string BuyerEmail { get; set; }
        public virtual string BuyerAddress { get; set; }
        public virtual List<OrderItemModel> OrderItems { get; set; }
    }
}