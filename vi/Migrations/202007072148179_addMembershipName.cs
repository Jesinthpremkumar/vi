namespace vi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addMembershipName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MembershipTypes", "MembershipName", c => c.String(maxLength: 255));
        }
        
        public override void Down()
        {
            DropColumn("dbo.MembershipTypes", "MembershipName");
        }
    }
}
