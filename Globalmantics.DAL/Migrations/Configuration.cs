namespace Globalmantics.DAL.Migrations
{
    using Globalmantics.Domain;
    using System.Data.Entity.Migrations;

    public sealed class Configuration : DbMigrationsConfiguration<GlobalmanticsContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(GlobalmanticsContext context)
        {
            context.CatalogItems.AddOrUpdate(x => x.Sku, CatalogItem.Create
            (
                sku: "CAFE-314",
                description: "1 Pound Guatemalan Coffee Beans",
                unitPrice: 18.80m
            ), CatalogItem.Create
            (
                sku: "CAFE-272",
                description: "1 Pound Ethiopian Coffee Beans",
                unitPrice: 6.60m
            ), CatalogItem.Create
            (
                sku: "DR-4142",
                description: "Drum roasting kit",
                unitPrice: 425.00m
            ));
        }
    }
}
