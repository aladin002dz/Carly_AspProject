namespace Carly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addRequirementNameInCarModel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Cars", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Cars", "Name", c => c.String());
        }
    }
}
