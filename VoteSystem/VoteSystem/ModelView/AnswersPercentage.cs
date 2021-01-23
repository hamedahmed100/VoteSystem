using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VoteSystem.ModelView
{
   

    public class AnswersPercentage
    {
        public int Question_Id { get; set; }
        public string TheAnswer { get; set; }
        public Decimal votePercentage { get; set; }
    }
}