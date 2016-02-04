namespace Business.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SalesPersonData : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SalesPersonSales",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SalesPerson = c.String(),
                        SoftwareSales = c.Int(nullable: false),
                        ServicesSales = c.Int(nullable: false),
                        SupportSales = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SalesPersonSales");
        }
    }
}
