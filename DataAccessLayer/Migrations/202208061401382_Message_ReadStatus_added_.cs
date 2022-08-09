namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Message_ReadStatus_added_ : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "MessageStatus", c => c.Boolean(nullable: false));
            DropColumn("dbo.Messages", "MessgeStatus");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Messages", "MessgeStatus", c => c.Boolean(nullable: false));
            DropColumn("dbo.Messages", "MessageStatus");
        }
    }
}
