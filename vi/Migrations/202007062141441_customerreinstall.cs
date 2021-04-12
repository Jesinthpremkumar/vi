namespace vi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class customerreinstall : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                  "dbo.customers",
                  c => new
                  {
                      id = c.Int(nullable: false, identity: true),
                      name = c.String(),
                      isSubscribedToNewsletter = c.Boolean(nullable: false),
                      MembershipTypeId = c.Byte(nullable: false),
                  })
                  .PrimaryKey(t => t.id)
                  .ForeignKey("dbo.MembershipTypes", t => t.MembershipTypeId, cascadeDelete: true)
                  .Index(t => t.MembershipTypeId);
            AlterColumn("dbo.customers", "name", c => c.String(nullable: false, maxLength: 255));

        }
        
        public override void Down()
        {
            DropForeignKey("dbo.customers", "MembershipTypeId", "dbo.MembershipTypes");
            DropIndex("dbo.customers", new[] { "MembershipTypeId" });
           
            DropTable("dbo.customers");
        }
    }
}
