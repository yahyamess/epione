namespace DATA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v14 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.farahs", "Etat", c => c.String());
            AddColumn("dbo.farahs", "Justification", c => c.String());
            AddColumn("dbo.farahs", "Adresse", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.farahs", "Adresse");
            DropColumn("dbo.farahs", "Justification");
            DropColumn("dbo.farahs", "Etat");
        }
    }
}
