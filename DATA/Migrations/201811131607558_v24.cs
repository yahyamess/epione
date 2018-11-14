namespace DATA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v24 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Parcours", "Etatrdv", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Parcours", "Etatrdv");
        }
    }
}
