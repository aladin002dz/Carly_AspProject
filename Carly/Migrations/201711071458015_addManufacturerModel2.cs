namespace Carly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addManufacturerModel2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Manufacturers",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            /*
            AddColumn("dbo.Cars", "ManufacturerId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Cars", "ManufacturerId");
            AddForeignKey("dbo.Cars", "ManufacturerId", "dbo.Manufacturers", "Id", cascadeDelete: true);
            DropColumn("dbo.Cars", "Manufacturer");
            */
        }
        
        public override void Down()
        {
            /*
            AddColumn("dbo.Cars", "Manufacturer", c => c.String());
            DropForeignKey("dbo.Cars", "ManufacturerId", "dbo.Manufacturers");
            DropIndex("dbo.Cars", new[] { "ManufacturerId" });
            DropColumn("dbo.Cars", "ManufacturerId");
            */
            DropTable("dbo.Manufacturers");
        }
    }
}
