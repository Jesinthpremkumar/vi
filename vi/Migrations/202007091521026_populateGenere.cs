namespace vi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class populateGenere : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres (id,genre) VALUES(1,'Comedy')");
            Sql("INSERT INTO Genres (id,genre) VALUES(2,'Action')");
            Sql("INSERT INTO Genres (id,genre) VALUES(3,'Horror')");
            Sql("INSERT INTO Genres (id,genre) VALUES(4,'Animation')");
        }
        
        public override void Down()
        {
        }
    }
}
