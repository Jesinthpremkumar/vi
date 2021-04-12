namespace vi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class genretoType : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.movies", name: "genreId_id", newName: "genreType_id");
            RenameIndex(table: "dbo.movies", name: "IX_genreId_id", newName: "IX_genreType_id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.movies", name: "IX_genreType_id", newName: "IX_genreId_id");
            RenameColumn(table: "dbo.movies", name: "genreType_id", newName: "genreId_id");
        }
    }
}
