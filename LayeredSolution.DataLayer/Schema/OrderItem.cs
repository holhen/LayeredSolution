﻿namespace LayeredSolution.DataLayer.Schema
{
    public class OrderItem
    {
        public virtual int Id { get; set; }
        public virtual int? OrderId { get; set; }
        public virtual Order Order { get; set; }
        public virtual int? ProductId { get; set; }
        public virtual Product Product { get; set; }
        public virtual int Quantity { get; set; }
        public virtual int Price { get; set; }
    }
}
