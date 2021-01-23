using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using VoteSystem.Models;

namespace VoteSystem
{
    public class VoteContext : DbContext
    {
        public VoteContext() :base("name=DefaultConnection")
        {

        }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<VotedQuestion> VotedQuestions { get; set; }
    }
}