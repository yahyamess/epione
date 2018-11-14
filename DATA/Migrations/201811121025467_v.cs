namespace DATA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PlusMeds",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        IDMed = c.Int(nullable: false),
                        specialieProfondu = c.String(),
                        Hopital = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PlusMeds");
        }
    }
}
