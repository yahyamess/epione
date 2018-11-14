namespace DATA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v44 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.RDVs", "idPatient");
            DropColumn("dbo.RDVs", "idMedecien");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RDVs", "idMedecien", c => c.Int(nullable: false));
            AddColumn("dbo.RDVs", "idPatient", c => c.Int(nullable: false));
        }
    }
}
