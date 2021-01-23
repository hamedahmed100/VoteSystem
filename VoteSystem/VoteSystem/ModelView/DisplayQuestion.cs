using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VoteSystem.Models;

namespace VoteSystem.ModelView
{
    public class DisplayQuestion
    {

        public Question Question { get; set; }

        public List<Answer> Answers { get; set; }
    }
}