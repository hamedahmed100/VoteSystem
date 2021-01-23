namespace VoteSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeColumnName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Answers", "TheAnswer", c => c.String());
            DropColumn("dbo.Answers", "Case");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Answers", "Case", c => c.String());
            DropColumn("dbo.Answers", "TheAnswer");
        }
    }
}
