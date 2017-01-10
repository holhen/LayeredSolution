using LayeredSolution.BusinessLayer.Common;
using LayeredSolution.DataLayer.Schema;

namespace LayeredSolution.DataLayer.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<LayeredSolution.DataLayer.SampleContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(LayeredSolution.DataLayer.SampleContext context)
        {
            if (!context.Products.Any())
            {
                context.Products.Add(new Product
                {
                    ProductNo = "1234",
                    Name= "Android Phone",
                    Price = 1234,
                });
                context.Products.Add(new Product
                {
                    ProductNo = "2345",
                    Name = "Windows Phone",
                    Price = 2345
                });
                context.Products.Add(new Product
                {
                    ProductNo = "3456",
                    Name = "I Phone",
                    Price = 3456
                });
            }
            if (!context.Employees.Any(e => e.Role == "admin"))
            {
                context.Employees.Add(
                    new EmployeeEntity
                    {
                        Name = "Adminisztrátor",
                        UserName = "admin",
                        Password = PasswordHelper.EncryptPassword("admin"),
                        Position = "Adminisztrátor",
                        Role = "admin"
                    });
            }
        }
    }
}
