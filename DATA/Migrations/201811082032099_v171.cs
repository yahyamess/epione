namespace DATA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v171 : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.farahs");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.farahs",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        NomMedecin = c.String(),
                        Specialite = c.String(),
                        Maladie = c.String(),
                        date = c.DateTime(nullable: false),
                        Etat = c.String(),
                        Justification = c.String(),
                        Adresse = c.String(),
                        idPatient = c.Int(nullable: false),
                        idMedecin = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
    }
}
