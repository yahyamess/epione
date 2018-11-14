namespace DATA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class vghf : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Programmes", "ville", c => c.String());
            AddColumn("dbo.Programmes", "maladi", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Programmes", "maladi");
            DropColumn("dbo.Programmes", "ville");
        }
    }
}
