namespace DATA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v5131 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Chats",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        idPat = c.Int(nullable: false),
                        idMed = c.Int(nullable: false),
                        contenu = c.String(),
                        date = c.DateTime(nullable: false),
                        etat = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Motifs",
                c => new
                    {
                        motifID = c.Int(nullable: false, identity: true),
                        idPatient = c.Int(nullable: false),
                        description = c.String(),
                    })
                .PrimaryKey(t => t.motifID);
            
            CreateTable(
                "dbo.Notifications",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        idMedecin = c.Int(nullable: false),
                        idPatient = c.Int(nullable: false),
                        contenu = c.String(),
                        date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Parcours",
                c => new
                    {
                        ParcoursID = c.String(nullable: false, maxLength: 128),
                        IDPatient = c.String(),
                        IdMedecin = c.String(),
                        NomMedecin = c.String(),
                        Specialite = c.String(),
                        Maladie = c.String(),
                        date = c.DateTime(nullable: false),
                        Etat = c.String(),
                        Justification = c.String(),
                        Adresse = c.String(),
                    })
                .PrimaryKey(t => t.ParcoursID);
            
            CreateTable(
                "dbo.Programmes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        idMed = c.Int(nullable: false),
                        idRdv = c.Int(nullable: false),
                        DateDebutR = c.String(),
                        DateFinR = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Ratings",
                c => new
                    {
                        idPat = c.Int(nullable: false, identity: true),
                        idMed = c.Int(nullable: false),
                        nbrEtoile = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idPat);
            
            CreateTable(
                "dbo.Rapports",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        idMed = c.Int(nullable: false),
                        idPet = c.Int(nullable: false),
                        picture = c.String(),
                        description = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.RDVs",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        idPatient = c.Int(nullable: false),
                        idMedecien = c.Int(nullable: false),
                        nom = c.String(),
                        prenom = c.String(),
                        date = c.DateTime(nullable: false),
                        ville = c.String(),
                        maladi = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        RoleId = c.Int(nullable: false),
                        Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Soins",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        idMed = c.Int(nullable: false),
                        soin = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LastName = c.String(),
                        FirstName = c.String(),
                        Email = c.String(maxLength: 256),
                        Password = c.String(nullable: false),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                        nom = c.String(),
                        prenom = c.String(),
                        specialite = c.String(),
                        source = c.String(),
                        localisation = c.String(),
                        idSocial = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.Int(nullable: false),
                        Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Soins");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.RDVs");
            DropTable("dbo.Rapports");
            DropTable("dbo.Ratings");
            DropTable("dbo.Programmes");
            DropTable("dbo.Parcours");
            DropTable("dbo.Notifications");
            DropTable("dbo.Motifs");
            DropTable("dbo.Chats");
        }
    }
}
