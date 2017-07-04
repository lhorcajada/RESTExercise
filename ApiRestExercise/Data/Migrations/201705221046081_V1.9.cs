namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class V19 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Address_Street", c => c.String());
            AddColumn("dbo.Users", "Address_PostalCode", c => c.String());
            AddColumn("dbo.Users", "Address_Province", c => c.String());
            AddColumn("dbo.Users", "Address_Country", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "Address_Country");
            DropColumn("dbo.Users", "Address_Province");
            DropColumn("dbo.Users", "Address_PostalCode");
            DropColumn("dbo.Users", "Address_Street");
        }
    }
}
