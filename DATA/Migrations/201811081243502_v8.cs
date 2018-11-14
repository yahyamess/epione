namespace DATA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v8 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.farahs", "NomMedecin", c => c.String());
            AddColumn("dbo.farahs", "Specialite", c => c.String());
            AddColumn("dbo.farahs", "Maladie", c => c.String());
            DropColumn("dbo.farahs", "Prenom");
        }
        
        public override void Down()
        {
            AddColumn("dbo.farahs", "Prenom", c => c.String());
            DropColumn("dbo.farahs", "Maladie");
            DropColumn("dbo.farahs", "Specialite");
            DropColumn("dbo.farahs", "NomMedecin");
        }
    }
}
