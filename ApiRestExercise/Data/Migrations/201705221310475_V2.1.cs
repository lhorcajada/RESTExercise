namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class V21 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "DeliveryAddress_Street", c => c.String());
            AddColumn("dbo.Users", "DeliveryAddress_PostalCode", c => c.String());
            AddColumn("dbo.Users", "DeliveryAddress_Province", c => c.String());
            AddColumn("dbo.Users", "DeliveryAddress_Country", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "DeliveryAddress_Country");
            DropColumn("dbo.Users", "DeliveryAddress_Province");
            DropColumn("dbo.Users", "DeliveryAddress_PostalCode");
            DropColumn("dbo.Users", "DeliveryAddress_Street");
        }
    }
}
