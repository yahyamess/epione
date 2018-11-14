namespace DATA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v16 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Parcours");
            AddColumn("dbo.Parcours", "id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Parcours", "id");
            DropColumn("dbo.Parcours", "ParcoursID");
            DropColumn("dbo.Parcours", "Maladie");
            DropColumn("dbo.Parcours", "date");
            DropColumn("dbo.Parcours", "Etat");
            DropColumn("dbo.Parcours", "Justification");
            DropColumn("dbo.Parcours", "Adresse");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Parcours", "Adresse", c => c.String());
            AddColumn("dbo.Parcours", "Justification", c => c.String());
            AddColumn("dbo.Parcours", "Etat", c => c.String());
            AddColumn("dbo.Parcours", "date", c => c.DateTime(nullable: false));
            AddColumn("dbo.Parcours", "Maladie", c => c.String());
            AddColumn("dbo.Parcours", "ParcoursID", c => c.String(nullable: false, maxLength: 128));
            DropPrimaryKey("dbo.Parcours");
            DropColumn("dbo.Parcours", "id");
            AddPrimaryKey("dbo.Parcours", "ParcoursID");
        }
    }
}
