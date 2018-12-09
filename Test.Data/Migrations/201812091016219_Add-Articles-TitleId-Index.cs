namespace Test.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddArticlesTitleIdIndex : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Articles", "TitleId", true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Articles", new[] { "TitleId" });
        }
    }
}
