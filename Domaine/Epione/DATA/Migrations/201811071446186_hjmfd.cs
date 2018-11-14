namespace DATA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class hjmfd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PlusMeds",
                c => new
                    {
                        MedID = c.Int(nullable: false, identity: true),
                        specialieProfondu = c.String(),
                        Hopital = c.String(),
                    })
                .PrimaryKey(t => t.MedID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PlusMeds");
        }
    }
}
