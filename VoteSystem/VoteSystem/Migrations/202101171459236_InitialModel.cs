namespace VoteSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Answers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MyAnswer = c.Int(nullable: false),
                        Question_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Questions", t => t.Question_Id)
                .Index(t => t.Question_Id);
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.VotedQuestions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Answer_Id = c.Int(),
                        Question_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Answers", t => t.Answer_Id)
                .ForeignKey("dbo.Questions", t => t.Question_Id)
                .Index(t => t.Answer_Id)
                .Index(t => t.Question_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VotedQuestions", "Question_Id", "dbo.Questions");
            DropForeignKey("dbo.VotedQuestions", "Answer_Id", "dbo.Answers");
            DropForeignKey("dbo.Answers", "Question_Id", "dbo.Questions");
            DropIndex("dbo.VotedQuestions", new[] { "Question_Id" });
            DropIndex("dbo.VotedQuestions", new[] { "Answer_Id" });
            DropIndex("dbo.Answers", new[] { "Question_Id" });
            DropTable("dbo.VotedQuestions");
            DropTable("dbo.Questions");
            DropTable("dbo.Answers");
        }
    }
}
