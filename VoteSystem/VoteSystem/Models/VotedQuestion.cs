using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace VoteSystem.Models
{
    public class VotedQuestion
    {
        public int Id { get; set; }
        [Required]
        public int QuestionId { get; set; }
        [Required]
        public int AnswerId { get; set; }

    }
}