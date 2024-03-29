﻿namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _admin_password_salt_added : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Admins", "PasswordSalt", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Admins", "PasswordSalt");
        }
    }
}
