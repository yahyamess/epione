namespace DATA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v7 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Parcours", "IDPatient");
            DropColumn("dbo.Parcours", "IdMedecin");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Parcours", "IdMedecin", c => c.String());
            AddColumn("dbo.Parcours", "IDPatient", c => c.String());
        }
    }
}
