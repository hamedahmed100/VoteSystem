using PagedList;
using PagedList.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VoteSystem.Models;

namespace VoteSystem.ModelView
{
    public class VotePercentage
    {
        public PagedList<Question> Questions { get; set; }
        public List<AnswersPercentage> AnswersPercentages { get; set; }

        public int PageNo { get; set; }
    }
}