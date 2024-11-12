namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Contents", "WriterID", "dbo.Writers");
            DropForeignKey("dbo.Contents", "Heading_HeadingID", "dbo.Headings");
            DropIndex("dbo.Contents", new[] { "WriterID" });
            DropIndex("dbo.Contents", new[] { "Heading_HeadingID" });
            RenameColumn(table: "dbo.Contents", name: "Heading_HeadingID", newName: "HeadingID");
            AlterColumn("dbo.Contents", "HeadingID", c => c.Int(nullable: false));
            CreateIndex("dbo.Contents", "HeadingID");
            AddForeignKey("dbo.Contents", "HeadingID", "dbo.Headings", "HeadingID", cascadeDelete: true);
            DropColumn("dbo.Contents", "WriterID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Contents", "WriterID", c => c.Int(nullable: false));
            DropForeignKey("dbo.Contents", "HeadingID", "dbo.Headings");
            DropIndex("dbo.Contents", new[] { "HeadingID" });
            AlterColumn("dbo.Contents", "HeadingID", c => c.Int());
            RenameColumn(table: "dbo.Contents", name: "HeadingID", newName: "Heading_HeadingID");
            CreateIndex("dbo.Contents", "Heading_HeadingID");
            CreateIndex("dbo.Contents", "WriterID");
            AddForeignKey("dbo.Contents", "Heading_HeadingID", "dbo.Headings", "HeadingID");
            AddForeignKey("dbo.Contents", "WriterID", "dbo.Writers", "WriterID", cascadeDelete: true);
        }
    }
}
