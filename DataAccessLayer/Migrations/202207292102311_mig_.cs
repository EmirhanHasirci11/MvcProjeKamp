namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_ : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Writers", "WriterTitle", c => c.String(maxLength: 50));
            AlterColumn("dbo.Writers", "WriterMail", c => c.String(maxLength: 200));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Writers", "WriterMail", c => c.String(maxLength: 50));
            AlterColumn("dbo.Writers", "WriterTitle", c => c.String(maxLength: 200));
        }
    }
}
