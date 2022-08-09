namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _admin_username_validation_removed : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Admins", "AdminUserName", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Admins", "AdminUserName", c => c.String(maxLength: 50));
        }
    }
}
