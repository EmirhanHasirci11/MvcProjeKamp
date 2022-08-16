namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _ImageFile_DateAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ImageFiles", "ImageDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.ImageFiles", "ImagePath", c => c.String(maxLength: 500));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ImageFiles", "ImagePath", c => c.String(maxLength: 250));
            DropColumn("dbo.ImageFiles", "ImageDate");
        }
    }
}
