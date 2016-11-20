namespace Musicology.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialSetup : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Albums",
                c => new
                    {
                        AlbumID = c.Int(nullable: false, identity: true),
                        AlbumName = c.String(),
                        Artist = c.String(),
                        Genre = c.String(),
                        AlbumPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.AlbumID);
            
            CreateTable(
                "dbo.AlbumRatings",
                c => new
                    {
                        AlbumRatingID = c.Int(nullable: false, identity: true),
                        AlbumRatingNum = c.Int(nullable: false),
                        AlbumReview = c.String(),
                        Albums_AlbumID = c.Int(),
                        AppUsers_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.AlbumRatingID)
                .ForeignKey("dbo.Albums", t => t.Albums_AlbumID)
                .ForeignKey("dbo.AspNetUsers", t => t.AppUsers_Id)
                .Index(t => t.Albums_AlbumID)
                .Index(t => t.AppUsers_Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Address = c.String(),
                        Email = c.String(maxLength: 256),
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
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
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
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Artists",
                c => new
                    {
                        ArtistID = c.Int(nullable: false, identity: true),
                        ArtistName = c.String(),
                        Genre = c.String(),
                    })
                .PrimaryKey(t => t.ArtistID);
            
            CreateTable(
                "dbo.ArtistRatings",
                c => new
                    {
                        ArtistRatingID = c.Int(nullable: false, identity: true),
                        ArtistRatingNum = c.Int(nullable: false),
                        ArtistReview = c.String(),
                        AppUsers_Id = c.String(maxLength: 128),
                        Artists_ArtistID = c.Int(),
                    })
                .PrimaryKey(t => t.ArtistRatingID)
                .ForeignKey("dbo.AspNetUsers", t => t.AppUsers_Id)
                .ForeignKey("dbo.Artists", t => t.Artists_ArtistID)
                .Index(t => t.AppUsers_Id)
                .Index(t => t.Artists_ArtistID);
            
            CreateTable(
                "dbo.Songs",
                c => new
                    {
                        SongID = c.Int(nullable: false, identity: true),
                        SongTitle = c.String(),
                        Artist = c.String(),
                        Genre = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Album = c.String(),
                    })
                .PrimaryKey(t => t.SongID);
            
            CreateTable(
                "dbo.OrderItems",
                c => new
                    {
                        OrderItemID = c.Int(nullable: false, identity: true),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SongPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AlbumPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Albums_AlbumID = c.Int(),
                        Songs_SongID = c.Int(),
                    })
                .PrimaryKey(t => t.OrderItemID)
                .ForeignKey("dbo.Albums", t => t.Albums_AlbumID)
                .ForeignKey("dbo.Songs", t => t.Songs_SongID)
                .Index(t => t.Albums_AlbumID)
                .Index(t => t.Songs_SongID);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderID = c.Int(nullable: false, identity: true),
                        Subtotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Tax = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AppUsers_Id = c.String(maxLength: 128),
                        CreditCards_CreditCardID = c.Int(),
                    })
                .PrimaryKey(t => t.OrderID)
                .ForeignKey("dbo.AspNetUsers", t => t.AppUsers_Id)
                .ForeignKey("dbo.CreditCards", t => t.CreditCards_CreditCardID)
                .Index(t => t.AppUsers_Id)
                .Index(t => t.CreditCards_CreditCardID);
            
            CreateTable(
                "dbo.CreditCards",
                c => new
                    {
                        CreditCardID = c.Int(nullable: false, identity: true),
                        CreditCardNumber = c.Long(nullable: false),
                        CreditCardType = c.String(),
                        ExpMonth = c.Int(nullable: false),
                        ExpYear = c.Int(nullable: false),
                        SecurityCode = c.Int(nullable: false),
                        AppUsers_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.CreditCardID)
                .ForeignKey("dbo.AspNetUsers", t => t.AppUsers_Id)
                .Index(t => t.AppUsers_Id);
            
            CreateTable(
                "dbo.SongRatings",
                c => new
                    {
                        SongRatingID = c.Int(nullable: false, identity: true),
                        SongRatingNum = c.Int(nullable: false),
                        SongReview = c.String(),
                        AppUsers_Id = c.String(maxLength: 128),
                        Songs_SongID = c.Int(),
                    })
                .PrimaryKey(t => t.SongRatingID)
                .ForeignKey("dbo.AspNetUsers", t => t.AppUsers_Id)
                .ForeignKey("dbo.Songs", t => t.Songs_SongID)
                .Index(t => t.AppUsers_Id)
                .Index(t => t.Songs_SongID);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.ArtistAlbums",
                c => new
                    {
                        Artist_ArtistID = c.Int(nullable: false),
                        Album_AlbumID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Artist_ArtistID, t.Album_AlbumID })
                .ForeignKey("dbo.Artists", t => t.Artist_ArtistID, cascadeDelete: true)
                .ForeignKey("dbo.Albums", t => t.Album_AlbumID, cascadeDelete: true)
                .Index(t => t.Artist_ArtistID)
                .Index(t => t.Album_AlbumID);
            
            CreateTable(
                "dbo.SongAlbums",
                c => new
                    {
                        Song_SongID = c.Int(nullable: false),
                        Album_AlbumID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Song_SongID, t.Album_AlbumID })
                .ForeignKey("dbo.Songs", t => t.Song_SongID, cascadeDelete: true)
                .ForeignKey("dbo.Albums", t => t.Album_AlbumID, cascadeDelete: true)
                .Index(t => t.Song_SongID)
                .Index(t => t.Album_AlbumID);
            
            CreateTable(
                "dbo.SongArtists",
                c => new
                    {
                        Song_SongID = c.Int(nullable: false),
                        Artist_ArtistID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Song_SongID, t.Artist_ArtistID })
                .ForeignKey("dbo.Songs", t => t.Song_SongID, cascadeDelete: true)
                .ForeignKey("dbo.Artists", t => t.Artist_ArtistID, cascadeDelete: true)
                .Index(t => t.Song_SongID)
                .Index(t => t.Artist_ArtistID);
            
            CreateTable(
                "dbo.OrderOrderItems",
                c => new
                    {
                        Order_OrderID = c.Int(nullable: false),
                        OrderItem_OrderItemID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Order_OrderID, t.OrderItem_OrderItemID })
                .ForeignKey("dbo.Orders", t => t.Order_OrderID, cascadeDelete: true)
                .ForeignKey("dbo.OrderItems", t => t.OrderItem_OrderItemID, cascadeDelete: true)
                .Index(t => t.Order_OrderID)
                .Index(t => t.OrderItem_OrderItemID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.SongRatings", "Songs_SongID", "dbo.Songs");
            DropForeignKey("dbo.SongRatings", "AppUsers_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.OrderItems", "Songs_SongID", "dbo.Songs");
            DropForeignKey("dbo.OrderOrderItems", "OrderItem_OrderItemID", "dbo.OrderItems");
            DropForeignKey("dbo.OrderOrderItems", "Order_OrderID", "dbo.Orders");
            DropForeignKey("dbo.Orders", "CreditCards_CreditCardID", "dbo.CreditCards");
            DropForeignKey("dbo.CreditCards", "AppUsers_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Orders", "AppUsers_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.OrderItems", "Albums_AlbumID", "dbo.Albums");
            DropForeignKey("dbo.SongArtists", "Artist_ArtistID", "dbo.Artists");
            DropForeignKey("dbo.SongArtists", "Song_SongID", "dbo.Songs");
            DropForeignKey("dbo.SongAlbums", "Album_AlbumID", "dbo.Albums");
            DropForeignKey("dbo.SongAlbums", "Song_SongID", "dbo.Songs");
            DropForeignKey("dbo.ArtistRatings", "Artists_ArtistID", "dbo.Artists");
            DropForeignKey("dbo.ArtistRatings", "AppUsers_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.ArtistAlbums", "Album_AlbumID", "dbo.Albums");
            DropForeignKey("dbo.ArtistAlbums", "Artist_ArtistID", "dbo.Artists");
            DropForeignKey("dbo.AlbumRatings", "AppUsers_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AlbumRatings", "Albums_AlbumID", "dbo.Albums");
            DropIndex("dbo.OrderOrderItems", new[] { "OrderItem_OrderItemID" });
            DropIndex("dbo.OrderOrderItems", new[] { "Order_OrderID" });
            DropIndex("dbo.SongArtists", new[] { "Artist_ArtistID" });
            DropIndex("dbo.SongArtists", new[] { "Song_SongID" });
            DropIndex("dbo.SongAlbums", new[] { "Album_AlbumID" });
            DropIndex("dbo.SongAlbums", new[] { "Song_SongID" });
            DropIndex("dbo.ArtistAlbums", new[] { "Album_AlbumID" });
            DropIndex("dbo.ArtistAlbums", new[] { "Artist_ArtistID" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.SongRatings", new[] { "Songs_SongID" });
            DropIndex("dbo.SongRatings", new[] { "AppUsers_Id" });
            DropIndex("dbo.CreditCards", new[] { "AppUsers_Id" });
            DropIndex("dbo.Orders", new[] { "CreditCards_CreditCardID" });
            DropIndex("dbo.Orders", new[] { "AppUsers_Id" });
            DropIndex("dbo.OrderItems", new[] { "Songs_SongID" });
            DropIndex("dbo.OrderItems", new[] { "Albums_AlbumID" });
            DropIndex("dbo.ArtistRatings", new[] { "Artists_ArtistID" });
            DropIndex("dbo.ArtistRatings", new[] { "AppUsers_Id" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AlbumRatings", new[] { "AppUsers_Id" });
            DropIndex("dbo.AlbumRatings", new[] { "Albums_AlbumID" });
            DropTable("dbo.OrderOrderItems");
            DropTable("dbo.SongArtists");
            DropTable("dbo.SongAlbums");
            DropTable("dbo.ArtistAlbums");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.SongRatings");
            DropTable("dbo.CreditCards");
            DropTable("dbo.Orders");
            DropTable("dbo.OrderItems");
            DropTable("dbo.Songs");
            DropTable("dbo.ArtistRatings");
            DropTable("dbo.Artists");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AlbumRatings");
            DropTable("dbo.Albums");
        }
    }
}
