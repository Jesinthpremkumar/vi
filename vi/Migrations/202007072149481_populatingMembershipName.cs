namespace vi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class populatingMembershipName : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE MembershipTypes SET MembershipName='Pay as you go' WHERE id=1");
            Sql("UPDATE MembershipTypes SET MembershipName='Monthly' WHERE id=2");
            Sql("UPDATE MembershipTypes SET MembershipName='Quaterly' WHERE id=3");
            Sql("UPDATE MembershipTypes SET MembershipName='Yearly' WHERE id=4");

        }

        public override void Down()
        {
        }
    }
}
