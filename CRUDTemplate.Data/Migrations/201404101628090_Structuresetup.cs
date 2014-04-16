namespace SportsDB.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Structuresetup : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Athletes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Position = c.String(),
                        Team = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Sports",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Acronym = c.String(),
                        Teams = c.Int(nullable: false),
                        Athleteid = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Athletes", t => t.Athleteid, cascadeDelete: true)
                .Index(t => t.Athleteid);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sports", "Athleteid", "dbo.Athletes");
            DropIndex("dbo.Sports", new[] { "Athleteid" });
            DropTable("dbo.Sports");
            DropTable("dbo.Athletes");
        }
    }
}
