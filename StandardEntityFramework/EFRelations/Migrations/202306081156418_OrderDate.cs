﻿namespace EFRelations.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OrderDate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "OrderDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "OrderDate");
        }
    }
}
