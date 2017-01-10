using System.Collections.Generic;

namespace LayeredSolution.DataLayer.Schema
{
    public class Product
    {
        public virtual int Id { get; set; }
        public virtual string ProductNo { get; set; }
        public virtual string Name { get; set; }
        public virtual int Price { get; set; }
        public virtual IList<OrderItem> OrderItems { get; set; }
    }
}