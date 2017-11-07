namespace Carly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addManufacturerToCarModel : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Manufacturers(Id, Name) VALUES (1,'Toyota')");
            Sql("INSERT INTO Manufacturers(Id, Name) VALUES (2,'Mercedes')");
            Sql("INSERT INTO Manufacturers(Id, Name) VALUES (3,'Tesla')");
            Sql("INSERT INTO Manufacturers(Id, Name) VALUES (4,'Chevrolet')");
            /*
            AddColumn("dbo.Cars", "ManufacturerId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Cars", "ManufacturerId");
            AddForeignKey("dbo.Cars", "ManufacturerId", "dbo.Manufacturers", "Id", cascadeDelete: true);
            */
        }

        public override void Down()
        {
            /*
            DropForeignKey("dbo.Cars", "ManufacturerId", "dbo.Manufacturers");
            DropIndex("dbo.Cars", new[] { "ManufacturerId" });
            DropColumn("dbo.Cars", "ManufacturerId");
            */
        }
    }
}
