namespace vi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class genre : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.movies");
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        id = c.Byte(nullable: false),
                        genre = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            AddColumn("dbo.movies", "genreId_id", c => c.Byte(nullable: false));
            AlterColumn("dbo.movies", "id", c => c.Byte(nullable: false));
            AddPrimaryKey("dbo.movies", "id");
            CreateIndex("dbo.movies", "genreId_id");
            AddForeignKey("dbo.movies", "genreId_id", "dbo.Genres", "id", cascadeDelete: true);
            DropColumn("dbo.movies", "genre");
        }
        
        public override void Down()
        {
            AddColumn("dbo.movies", "genre", c => c.String(nullable: false));
            DropForeignKey("dbo.movies", "genreId_id", "dbo.Genres");
            DropIndex("dbo.movies", new[] { "genreId_id" });
            DropPrimaryKey("dbo.movies");
            AlterColumn("dbo.movies", "id", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.movies", "genreId_id");
            DropTable("dbo.Genres");
            AddPrimaryKey("dbo.movies", "id");
        }
    }
}
