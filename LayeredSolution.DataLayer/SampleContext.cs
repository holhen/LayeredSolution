using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using LayeredSolution.DataLayer.Schema;

namespace LayeredSolution.DataLayer
{
    public class SampleContext : DbContext, ISampleContext
    {
        public SampleContext() : this("Webshop")
        {
            
        }
        public SampleContext(string connectionString) 
            : base(connectionString)
        {
            
        }

        public IDbSet<Product> Products
        {
            get { return Set<Product>(); }
        }

        public IDbSet<Order> Orders
        {
            get { return Set<Order>(); }
        }

        public IDbSet<OrderItem> OrderItems
        {
            get { return Set<OrderItem>(); }
        }

        public IDbSet<EmployeeEntity> Employees
        {
            get { return Set<EmployeeEntity>(); }
        }
    }
}