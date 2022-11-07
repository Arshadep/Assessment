namespace Test1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Requests",
                c => new
                    {
                        RequestId = c.Int(nullable: false, identity: true),
                        CreatedAt = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.RequestId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Requests");
        }
    }
}
