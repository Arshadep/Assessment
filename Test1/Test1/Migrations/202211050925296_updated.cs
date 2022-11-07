namespace Test1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updated : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Requests", "UpdatedAt", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Requests", "UpdatedAt", c => c.DateTime(nullable: false));
        }
    }
}
