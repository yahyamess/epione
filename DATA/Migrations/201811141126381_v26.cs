namespace DATA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v26 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Parcours", "NomMedecin", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Parcours", "NomMedecin", c => c.String(nullable: false));
        }
    }
}
