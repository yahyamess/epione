namespace DATA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v20 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Parcours", "idRDV", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Parcours", "idRDV");
        }
    }
}
