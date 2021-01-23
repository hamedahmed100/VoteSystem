using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VoteSystem.BL;
using VoteSystem.ModelView;
using PagedList;
namespace VoteSystem.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Admin(int page = 1)
        {
            VotePercentage votePercentage = new VotePercentage
            {
                AnswersPercentages = new AdminBL().getAnswersPercentage(),
                Questions = new AdminBL().GetQuestions(page),
                PageNo = page
            };

            ViewBag.msg = TempData["check"];
            return View(votePercentage);
        }

        [HttpPost]
        public ActionResult Admin(QuestionAnswers questionAnswers)
        {
            TempData["check"] = false;
            if (ModelState.IsValid)
            {
                TempData["check"] = true;
                new AdminBL().addQuestion(questionAnswers);
            }

            return RedirectToAction("Admin");
        }
    }
}