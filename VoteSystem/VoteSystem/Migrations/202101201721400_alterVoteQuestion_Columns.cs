namespace VoteSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class alterVoteQuestion_Columns : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.VotedQuestions", "Answer_Id", "dbo.Answers");
            DropForeignKey("dbo.VotedQuestions", "Question_Id", "dbo.Questions");
            DropIndex("dbo.VotedQuestions", new[] { "Answer_Id" });
            DropIndex("dbo.VotedQuestions", new[] { "Question_Id" });
            AddColumn("dbo.VotedQuestions", "QuestionId", c => c.Int(nullable: false));
            AddColumn("dbo.VotedQuestions", "AnswerId", c => c.Int(nullable: false));
            DropColumn("dbo.VotedQuestions", "Answer_Id");
            DropColumn("dbo.VotedQuestions", "Question_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.VotedQuestions", "Question_Id", c => c.Int());
            AddColumn("dbo.VotedQuestions", "Answer_Id", c => c.Int());
            DropColumn("dbo.VotedQuestions", "AnswerId");
            DropColumn("dbo.VotedQuestions", "QuestionId");
            CreateIndex("dbo.VotedQuestions", "Question_Id");
            CreateIndex("dbo.VotedQuestions", "Answer_Id");
            AddForeignKey("dbo.VotedQuestions", "Question_Id", "dbo.Questions", "Id");
            AddForeignKey("dbo.VotedQuestions", "Answer_Id", "dbo.Answers", "Id");
        }
    }
}
