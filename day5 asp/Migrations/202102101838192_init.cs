namespace day5_asp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.catalogs",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        desc = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.news",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        title = c.String(),
                        bref = c.String(),
                        details = c.String(),
                        date = c.DateTime(nullable: false),
                        img = c.String(),
                        attach = c.String(),
                        userID = c.Int(nullable: false),
                        catID = c.Int(nullable: false),
                        cat_id = c.Int(),
                        user_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.catalogs", t => t.cat_id)
                .ForeignKey("dbo.users", t => t.user_id)
                .Index(t => t.cat_id)
                .Index(t => t.user_id);
            
            CreateTable(
                "dbo.users",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        password = c.String(),
                        email = c.String(),
                        age = c.Int(nullable: false),
                        address = c.String(),
                        img = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.news", "user_id", "dbo.users");
            DropForeignKey("dbo.news", "cat_id", "dbo.catalogs");
            DropIndex("dbo.news", new[] { "user_id" });
            DropIndex("dbo.news", new[] { "cat_id" });
            DropTable("dbo.users");
            DropTable("dbo.news");
            DropTable("dbo.catalogs");
        }
    }
}
