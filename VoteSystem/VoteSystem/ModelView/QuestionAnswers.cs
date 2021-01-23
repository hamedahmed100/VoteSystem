using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using VoteSystem.Models;


namespace VoteSystem.ModelView
{
    public class QuestionAnswers
    {
        [Required(ErrorMessage = "Please enter Question")]
        public string Question { get; set; }
        [Required]
        public List<string> Answers { get; set; }
    }
}