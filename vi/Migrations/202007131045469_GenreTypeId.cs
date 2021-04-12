namespace vi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GenreTypeId : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.movies", name: "genreType_id", newName: "genreTypeId");
            RenameIndex(table: "dbo.movies", name: "IX_genreType_id", newName: "IX_genreTypeId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.movies", name: "IX_genreTypeId", newName: "IX_genreType_id");
            RenameColumn(table: "dbo.movies", name: "genreTypeId", newName: "genreType_id");
        }
    }
}
