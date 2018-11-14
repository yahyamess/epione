namespace DATA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v17 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Parcours", "Maladie", c => c.String());
            AddColumn("dbo.Parcours", "date", c => c.DateTime(nullable: false));
            AddColumn("dbo.Parcours", "Etat", c => c.String());
            AddColumn("dbo.Parcours", "Justification", c => c.String());
            AddColumn("dbo.Parcours", "Adresse", c => c.String());
            AddColumn("dbo.Parcours", "idPatient", c => c.Int(nullable: false));
            AddColumn("dbo.Parcours", "idMedecin", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Parcours", "idMedecin");
            DropColumn("dbo.Parcours", "idPatient");
            DropColumn("dbo.Parcours", "Adresse");
            DropColumn("dbo.Parcours", "Justification");
            DropColumn("dbo.Parcours", "Etat");
            DropColumn("dbo.Parcours", "date");
            DropColumn("dbo.Parcours", "Maladie");
        }
    }
}
