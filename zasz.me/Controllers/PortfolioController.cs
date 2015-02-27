using System.Web.Mvc;
using zasz.me.Integration.EntityFramework;
using zasz.me.Integration.MVC;
using zasz.me.Models;

namespace zasz.me.Controllers
{
    public class PortfolioController : BaseController
    {
        private readonly ICacheRepository caches;
        private readonly IAnswerRepository answers;

        public PortfolioController(ICacheRepository caches, IAnswerRepository answers)
        {
            this.caches = caches;
            this.answers = answers;
        }

        [DefaultAction]
        public ActionResult All()
        {
            return View();
        }


        public ViewResult StackExchange([Bind(Prefix = "id")] int pageNumber = 1)
        {
            var cache = caches.Get();
            var paged = answers.Page(cache, pageNumber - 1, 10);
            return View(paged);
        }
    }
}