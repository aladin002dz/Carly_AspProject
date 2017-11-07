namespace Carly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addNumberAvailableToCarModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cars", "NumberAvailable", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Cars", "NumberAvailable");
        }
    }
}
