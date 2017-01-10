using System;
using System.Data.Entity;
using LayeredSolution.DataLayer.Schema;

namespace LayeredSolution.DataLayer
{
    public interface ISampleContext
    {
        IDbSet<Product> Products { get; }
        IDbSet<Order> Orders { get; }
        IDbSet<OrderItem> OrderItems { get; }
        IDbSet<EmployeeEntity> Employees { get; }

        int SaveChanges();
    }
}
