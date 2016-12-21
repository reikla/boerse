namespace StockExchange.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class update1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OrdersModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdStock = c.String(),
                        Amount = c.Int(nullable: false),
                        Price = c.Double(nullable: false),
                        Type = c.String(),
                        TimeStamp = c.DateTime(nullable: false),
                        IdBoerse = c.String(),
                        Signature = c.String(),
                        IdBank = c.String(),
                        IdCustomer = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TxHistories",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Amount = c.Int(nullable: false),
                        Price = c.Double(nullable: false),
                        OrdersModel_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.OrdersModels", t => t.OrdersModel_Id)
                .Index(t => t.OrdersModel_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TxHistories", "OrdersModel_Id", "dbo.OrdersModels");
            DropIndex("dbo.TxHistories", new[] { "OrdersModel_Id" });
            DropTable("dbo.TxHistories");
            DropTable("dbo.OrdersModels");
        }
    }
}
