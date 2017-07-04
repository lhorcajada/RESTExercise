namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class V14 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Street", c => c.String(maxLength: 300));
            AddColumn("dbo.Users", "PostalCode", c => c.String(maxLength: 6));
            AddColumn("dbo.Users", "Province", c => c.String(maxLength: 80));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "Province");
            DropColumn("dbo.Users", "PostalCode");
            DropColumn("dbo.Users", "Street");
        }
    }
}
