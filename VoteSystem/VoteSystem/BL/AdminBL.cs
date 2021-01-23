using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VoteSystem.Models;
using VoteSystem.ModelView;

namespace VoteSystem.BL
{
    public class AdminBL
    {
        private readonly VoteContext dbContext;
        public AdminBL()
        {
            dbContext = new VoteContext();
        }

        public void addQuestion(QuestionAnswers quesionAnswers)
        {
            Question question = new Question
            {
                Content = quesionAnswers.Question
            };
            //Add Question
            dbContext.Questions.Add(question);


            Answer answer;
            foreach (var ans in quesionAnswers.Answers)
            {
                answer = new Answer
                {
                    Question = question,
                    TheAnswer = ans
                };
                //Add Answers
                dbContext.Answers.Add(answer);
            }


            //save Changes
            dbContext.SaveChanges();


        }


        public List<AnswersPercentage> getAnswersPercentage()
        {


            string query = "select a.Question_Id,a.TheAnswer ," +
                " ISNULL((count(v.id)*100.0/votCount.votes) , 0 ) votePercentage " +
                " from Answers a left outer join VotedQuestions v on a.Id = v.AnswerId " +
                "left outer join (select Questionid, count(AnswerId) as Votes " +
                "from VotedQuestions group by QuestionId) votCount " +
                "on votCount.QuestionId = a.Question_Id " +
                "group by a.Question_Id,a.TheAnswer ,votCount.votes order by a.Question_Id;";

            return dbContext.Database.SqlQuery<AnswersPercentage>(query).ToList();
        }


        public PagedList<Question> GetQuestions(int page)
        {
            return (PagedList<Question>)dbContext.Questions.Select(q => q).OrderBy(q => q.Id).ToPagedList(page, 3);
        }
    }
}