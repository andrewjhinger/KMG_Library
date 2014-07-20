namespace GameLibrary.Models.ContextNamespace1
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Context1Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BoardGameCategories",
                c => new
                    {
                        BGC = c.Int(nullable: false, identity: true),
                        BGCobjectID = c.Int(nullable: false),
                        value = c.String(),
                        BoardGame_ObjectID = c.Int(),
                    })
                .PrimaryKey(t => t.BGC)
                .ForeignKey("dbo.BoardGames", t => t.BoardGame_ObjectID)
                .Index(t => t.BoardGame_ObjectID);
            
            CreateTable(
                "dbo.BoardGames",
                c => new
                    {
                        ObjectID = c.Int(nullable: false),
                        yearPublished = c.Int(nullable: false),
                        minPlayers = c.Int(nullable: false),
                        maxPlayers = c.Int(nullable: false),
                        playingTime = c.Int(nullable: false),
                        age = c.Int(nullable: false),
                        description = c.String(),
                        imageThumnailURL = c.String(),
                        imageURL = c.String(),
                    })
                .PrimaryKey(t => t.ObjectID);
            
            CreateTable(
                "dbo.BoardGameDesigners",
                c => new
                    {
                        BGD = c.Int(nullable: false, identity: true),
                        BGDobjectID = c.Int(nullable: false),
                        value = c.String(),
                        BoardGame_ObjectID = c.Int(),
                    })
                .PrimaryKey(t => t.BGD)
                .ForeignKey("dbo.BoardGames", t => t.BoardGame_ObjectID)
                .Index(t => t.BoardGame_ObjectID);
            
            CreateTable(
                "dbo.BoardGameExpansions",
                c => new
                    {
                        BGE = c.Int(nullable: false, identity: true),
                        BGEobjectID = c.Int(nullable: false),
                        value = c.String(),
                        BoardGame_ObjectID = c.Int(),
                    })
                .PrimaryKey(t => t.BGE)
                .ForeignKey("dbo.BoardGames", t => t.BoardGame_ObjectID)
                .Index(t => t.BoardGame_ObjectID);
            
            CreateTable(
                "dbo.BoardGameHonors",
                c => new
                    {
                        BGH = c.Int(nullable: false, identity: true),
                        BGHobjectID = c.Int(nullable: false),
                        value = c.String(),
                        BoardGame_ObjectID = c.Int(),
                    })
                .PrimaryKey(t => t.BGH)
                .ForeignKey("dbo.BoardGames", t => t.BoardGame_ObjectID)
                .Index(t => t.BoardGame_ObjectID);
            
            CreateTable(
                "dbo.BoardGameMechanics",
                c => new
                    {
                        BGM = c.Int(nullable: false, identity: true),
                        BGMobjectID = c.Int(nullable: false),
                        value = c.String(),
                        BoardGame_ObjectID = c.Int(),
                    })
                .PrimaryKey(t => t.BGM)
                .ForeignKey("dbo.BoardGames", t => t.BoardGame_ObjectID)
                .Index(t => t.BoardGame_ObjectID);
            
            CreateTable(
                "dbo.BoardGameNames",
                c => new
                    {
                        BGN = c.Int(nullable: false, identity: true),
                        sortIndex = c.Int(nullable: false),
                        name = c.String(),
                        isPrimary = c.Boolean(nullable: false),
                        BoardGame_ObjectID = c.Int(),
                    })
                .PrimaryKey(t => t.BGN)
                .ForeignKey("dbo.BoardGames", t => t.BoardGame_ObjectID)
                .Index(t => t.BoardGame_ObjectID);
            
            CreateTable(
                "dbo.BoardGamePublishers",
                c => new
                    {
                        BGP = c.Int(nullable: false, identity: true),
                        BGPobjectID = c.Int(nullable: false),
                        value = c.String(),
                        BoardGame_ObjectID = c.Int(),
                    })
                .PrimaryKey(t => t.BGP)
                .ForeignKey("dbo.BoardGames", t => t.BoardGame_ObjectID)
                .Index(t => t.BoardGame_ObjectID);
            
            CreateTable(
                "dbo.BoardGameSubdomains",
                c => new
                    {
                        BGS = c.Int(nullable: false, identity: true),
                        BGSobjectID = c.Int(nullable: false),
                        value = c.String(),
                        BoardGame_ObjectID = c.Int(),
                    })
                .PrimaryKey(t => t.BGS)
                .ForeignKey("dbo.BoardGames", t => t.BoardGame_ObjectID)
                .Index(t => t.BoardGame_ObjectID);
            
            CreateTable(
                "dbo.BoardGameVersions",
                c => new
                    {
                        BGV = c.Int(nullable: false, identity: true),
                        BGVobjectID = c.Int(nullable: false),
                        value = c.String(),
                        BoardGame_ObjectID = c.Int(),
                    })
                .PrimaryKey(t => t.BGV)
                .ForeignKey("dbo.BoardGames", t => t.BoardGame_ObjectID)
                .Index(t => t.BoardGame_ObjectID);
            
            CreateTable(
                "dbo.CollectionItems",
                c => new
                    {
                        ObjectID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ObjectID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BoardGameVersions", "BoardGame_ObjectID", "dbo.BoardGames");
            DropForeignKey("dbo.BoardGameSubdomains", "BoardGame_ObjectID", "dbo.BoardGames");
            DropForeignKey("dbo.BoardGamePublishers", "BoardGame_ObjectID", "dbo.BoardGames");
            DropForeignKey("dbo.BoardGameNames", "BoardGame_ObjectID", "dbo.BoardGames");
            DropForeignKey("dbo.BoardGameMechanics", "BoardGame_ObjectID", "dbo.BoardGames");
            DropForeignKey("dbo.BoardGameHonors", "BoardGame_ObjectID", "dbo.BoardGames");
            DropForeignKey("dbo.BoardGameExpansions", "BoardGame_ObjectID", "dbo.BoardGames");
            DropForeignKey("dbo.BoardGameDesigners", "BoardGame_ObjectID", "dbo.BoardGames");
            DropForeignKey("dbo.BoardGameCategories", "BoardGame_ObjectID", "dbo.BoardGames");
            DropIndex("dbo.BoardGameVersions", new[] { "BoardGame_ObjectID" });
            DropIndex("dbo.BoardGameSubdomains", new[] { "BoardGame_ObjectID" });
            DropIndex("dbo.BoardGamePublishers", new[] { "BoardGame_ObjectID" });
            DropIndex("dbo.BoardGameNames", new[] { "BoardGame_ObjectID" });
            DropIndex("dbo.BoardGameMechanics", new[] { "BoardGame_ObjectID" });
            DropIndex("dbo.BoardGameHonors", new[] { "BoardGame_ObjectID" });
            DropIndex("dbo.BoardGameExpansions", new[] { "BoardGame_ObjectID" });
            DropIndex("dbo.BoardGameDesigners", new[] { "BoardGame_ObjectID" });
            DropIndex("dbo.BoardGameCategories", new[] { "BoardGame_ObjectID" });
            DropTable("dbo.CollectionItems");
            DropTable("dbo.BoardGameVersions");
            DropTable("dbo.BoardGameSubdomains");
            DropTable("dbo.BoardGamePublishers");
            DropTable("dbo.BoardGameNames");
            DropTable("dbo.BoardGameMechanics");
            DropTable("dbo.BoardGameHonors");
            DropTable("dbo.BoardGameExpansions");
            DropTable("dbo.BoardGameDesigners");
            DropTable("dbo.BoardGames");
            DropTable("dbo.BoardGameCategories");
        }
    }
}
