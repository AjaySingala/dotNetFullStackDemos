namespace EFTxns.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Standards : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Standards",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Associates", "Standard_Id", c => c.Int());
            CreateIndex("dbo.Associates", "Standard_Id");
            AddForeignKey("dbo.Associates", "Standard_Id", "dbo.Standards", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Associates", "Standard_Id", "dbo.Standards");
            DropIndex("dbo.Associates", new[] { "Standard_Id" });
            DropColumn("dbo.Associates", "Standard_Id");
            DropTable("dbo.Standards");
        }
    }
}
