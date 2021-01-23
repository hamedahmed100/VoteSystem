using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VoteSystem.BL;
using VoteSystem.Models;

namespace VoteSystem.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            HttpCookie cookie = Request.Cookies["QuestionIds"];//Get the existing cookie by cookie name.        

            if (cookie == null)
            {
                cookie = new HttpCookie("QuestionIds");
                cookie.Expires = DateTime.Now.AddHours(3000);
                Response.SetCookie(cookie);
            }

            var questionIdsToFilter = new List<int>();
            foreach (var Id in cookie.Values)
            {
                questionIdsToFilter.Add(Convert.ToInt32(Id));

            }

            ViewBag.msg = TempData["check"];
            return View(new UserBL().getQuestion(questionIdsToFilter));
        }

        [HttpPost]
        public ActionResult Index(VotedQuestion votedQuestion)
        {
            TempData["check"] = false;

            if (ModelState.IsValid)
            {
                var _votedQuestion = new UserBL().addVote(votedQuestion);

                TempData["check"] = true;

                #region setCookies for Voted Questions
                HttpCookie cookie = Request.Cookies["QuestionIds"];
                string QuestionId = Convert.ToString(votedQuestion.QuestionId);
                cookie.Values[QuestionId] = QuestionId;
                Response.Cookies.Add(cookie);
                #endregion

                #region setCookis for Voted Answers
                HttpCookie cookieAnswers = Request.Cookies["VoteId"];//Get the existing cookie by cookie name.        

                if (cookieAnswers == null)
                {
                    cookieAnswers = new HttpCookie("VoteId");
                    cookieAnswers.Expires = DateTime.Now.AddHours(3000);
                }
                string VoteId = Convert.ToString(_votedQuestion.Id);
                cookieAnswers.Values[VoteId] = VoteId;
                Response.Cookies.Add(cookieAnswers);
                #endregion
            }
            return RedirectToAction("Index");
        }

        public ActionResult DeleteCookies()
        {
            HttpCookie cookie = Request.Cookies["QuestionIds"];//Get the existing cookie by cookie name.
            cookie.Expires = DateTime.Now.AddSeconds(-1);
            Response.SetCookie(cookie);

            HttpCookie cookieAnswers = Request.Cookies["VoteId"];//Get the existing cookie by cookie name.        
            var votedAnswerIds = new List<int>();
            foreach (var Id in cookieAnswers.Values)
            {
                votedAnswerIds.Add(Convert.ToInt32(Id));
            }
            new UserBL().ResetVote(votedAnswerIds);
            cookieAnswers.Expires = DateTime.Now.AddSeconds(-1);
            Response.SetCookie(cookieAnswers);


            return RedirectToAction("Index");
        }
    }
}