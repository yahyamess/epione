namespace DATA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v15 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.farahs", "idPatient", c => c.Int(nullable: false));
            AddColumn("dbo.farahs", "idMedecin", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.farahs", "idMedecin");
            DropColumn("dbo.farahs", "idPatient");
        }
    }
}
