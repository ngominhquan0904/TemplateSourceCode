namespace EntityFrameworkTemplate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProvince : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "Province", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employees", "Province");
        }
    }
}
