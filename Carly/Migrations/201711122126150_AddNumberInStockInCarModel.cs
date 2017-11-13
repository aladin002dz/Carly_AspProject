namespace Carly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNumberInStockInCarModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cars", "NumberInStock", c => c.Int(nullable: false));
            Sql("UPDATE Cars SET NumberInStock = NumberAvailable ");
        }
        
        public override void Down()
        {
            DropColumn("dbo.Cars", "NumberInStock");
        }
    }
}
