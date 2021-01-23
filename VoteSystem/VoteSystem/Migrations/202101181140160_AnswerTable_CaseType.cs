namespace VoteSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AnswerTable_CaseType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Answers", "Case", c => c.String());
            DropColumn("dbo.Answers", "MyAnswer");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Answers", "MyAnswer", c => c.Int(nullable: false));
            DropColumn("dbo.Answers", "Case");
        }
    }
}
