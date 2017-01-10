namespace LayeredSolution.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Employees : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EmployeeEntities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Position = c.String(),
                        Password = c.String(),
                        Role = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.EmployeeEntities");
        }
    }
}
