using System.Web.Mvc;
using zasz.me.Integration.MVC;
using zasz.me.Services.Contracts;

namespace zasz.me.Controllers
{
    public class PortfolioController : BaseController
    {
        private readonly ISofuService service;

        public PortfolioController(ISofuService service)
        {
            this.service = service;
        }

        [DefaultAction]
        public ActionResult All()
        {
            return View();
        }


        public ViewResult StackExchange(int pageNumber = 1)
        {
            var questionIds = service.QuestionsAnswered();
            var titleIds = service.QuestionTitles(questionIds);
            return View(titleIds);
        }
    }
}