namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _draft_table_added : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Drafts",
                c => new
                    {
                        DraftID = c.Int(nullable: false, identity: true),
                        DraftSubject = c.String(maxLength: 100),
                        SenderMail = c.String(maxLength: 50),
                        ReceiverMail = c.String(maxLength: 50),
                        DraftContent = c.String(),
                        DraftStatus = c.Boolean(nullable: false),
                        DraftDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.DraftID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Drafts");
        }
    }
}
