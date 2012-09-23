using System.Web.Mvc;
using zasz.me.Integration.MVC;
using zasz.me.Models;
using zasz.me.Services.Contracts;

namespace zasz.me.Controllers
{
    public class PortfolioController : BaseController
    {
        private readonly ISoCacheRepository repository;

        public PortfolioController(ISoCacheRepository repository)
        {
            this.repository = repository;
        }

        [DefaultAction]
        public ActionResult All()
        {
            return View();
        }


        public ViewResult StackExchange(int pageNumber = 1)
        {
            var cache = repository.Get();
            var paged = repository.Page(cache, pageNumber, 10);
            return View(paged);
        }

        public ViewResult Tack(int id)
        {
            return View(id);
        }
    }
}