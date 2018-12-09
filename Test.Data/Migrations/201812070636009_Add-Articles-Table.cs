namespace Test.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddArticlesTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Articles",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true, defaultValueSql: "newsequentialid()"),
                        ApiId = c.Int(nullable: false),
                        IsFolder = c.Boolean(nullable: false),
                        RowVer = c.Int(nullable: false),
                        Title = c.String(maxLength: 255),
                        Body = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Articles");
        }
    }
}
