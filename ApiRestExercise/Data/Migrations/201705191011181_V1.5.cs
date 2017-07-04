namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class V15 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Country", c => c.String(maxLength: 80));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "Country");
        }
    }
}
