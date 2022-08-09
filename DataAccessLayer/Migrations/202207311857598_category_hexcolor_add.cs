namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class category_hexcolor_add : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "CategoryColor", c => c.String(maxLength: 8));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Categories", "CategoryColor");
        }
    }
}
