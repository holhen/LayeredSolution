using System.Collections.Generic;

namespace LayeredSolution.DataLayer.Schema
{
    public class Order
    {
        public virtual int Id { get; set; }
        public virtual string BuyerName { get; set; }
        public virtual string BuyerEmail { get; set; }
        public virtual string BuyerAddress { get; set; }
        public virtual List<OrderItem> OrderItems { get; set; }
    }
}