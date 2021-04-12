namespace vi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class customerBOD : DbMigration
    {
        public override void Up()
        {
             AddColumn("dbo.customers", "DateOfBirth", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.customers", "DateOfBirth");
        }
    }
}
