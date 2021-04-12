namespace vi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class movieTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.movies",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 255),
                        genre = c.String(nullable: false),
                        dateAdded = c.DateTime(nullable: false),
                        dateReleased = c.DateTime(nullable: false),
                        stockAvailable = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.movies");
        }
    }
}
