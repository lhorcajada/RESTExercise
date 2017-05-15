namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class V11 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "LastName", c => c.String(maxLength: 120));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "LastName");
        }
    }
}
