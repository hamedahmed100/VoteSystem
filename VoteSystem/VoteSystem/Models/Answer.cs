using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VoteSystem.Models
{
    public class Answer
    {
        public int Id { get; set; }
        public string TheAnswer { get; set; }
        public Question Question { get; set; }
    }
}