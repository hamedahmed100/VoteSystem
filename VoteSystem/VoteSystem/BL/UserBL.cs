using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VoteSystem.Models;
using VoteSystem.ModelView;

namespace VoteSystem.BL
{
    public class UserBL
    {
        private readonly VoteContext DbContext;
        public UserBL()
        {
            DbContext = new VoteContext();
        }


        public DisplayQuestion getQuestion(List<int> Ids)
        {
            DisplayQuestion displayQuestion = new DisplayQuestion();

            var exceptedQuestion = DbContext.Questions.Where(q => !Ids.Contains(q.Id)).FirstOrDefault();

            displayQuestion.Question = exceptedQuestion;
            // DbContext.Questions.Where(q=>q.Id==3).FirstOrDefault();

            if (displayQuestion.Question != null)
            {
                int QuestionID = displayQuestion.Question.Id;
                displayQuestion.Answers = DbContext.Answers.Where(A => A.Question.Id == QuestionID).ToList();
            }
            return displayQuestion;
        }

        public VotedQuestion addVote(VotedQuestion votedQuestion)
        {
            var entity = DbContext.VotedQuestions.Add(votedQuestion);
            DbContext.SaveChanges();
            return entity ;
        }

        public void ResetVote(List<int> voteIds)
        {
            var votedQuestion = DbContext.VotedQuestions.Where(v =>voteIds.Contains(v.Id));

            DbContext.VotedQuestions.RemoveRange(votedQuestion);
            DbContext.SaveChanges();
        }


    }
}