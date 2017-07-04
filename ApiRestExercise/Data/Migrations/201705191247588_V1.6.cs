namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class V16 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Users", "Street");
            DropColumn("dbo.Users", "PostalCode");
            DropColumn("dbo.Users", "Province");
            DropColumn("dbo.Users", "Country");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Country", c => c.String(maxLength: 80));
            AddColumn("dbo.Users", "Province", c => c.String(maxLength: 80));
            AddColumn("dbo.Users", "PostalCode", c => c.String(maxLength: 6));
            AddColumn("dbo.Users", "Street", c => c.String(maxLength: 300));
        }
    }
}
