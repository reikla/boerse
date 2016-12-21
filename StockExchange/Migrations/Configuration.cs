namespace StockExchange.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<StockExchange.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "StockExchange.Models.ApplicationDbContext";
        }

        protected override void Seed(StockExchange.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.StockModels.AddOrUpdate(
                new Models.StockModels { Id = "ATX", IdBoerse = "Afganistan", Name = "Austrian Traded Index", Price = 2523.39 },
                new Models.StockModels { Id = "GOOGL",  IdBoerse = "Afganistan", Name = "Alphabet Inc.", Price = 764.55 },
                new Models.StockModels { Id = "MSFT", IdBoerse = "Afganistan", Name = "Microsoft", Price = 59.46 },
                new Models.StockModels { Id = "AAPL", IdBoerse = "Afganistan", Name = "Apple", Price = 109.86}
                );

            context.OrdersModels.AddOrUpdate(
                new Models.OrdersModel("ATX", 100, 2000, "Buy", "customer.reimar"),
                new Models.OrdersModel("ATX", 30, 1800, "Sell", "customer.reimar"),
                new Models.OrdersModel("GOOGL", 100, 470, "Buy", "customer.reimar"));


            }
    }
}
