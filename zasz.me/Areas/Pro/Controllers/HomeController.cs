using System.Web.Mvc;
using zasz.me.Integration.MVC;
using zasz.me.Services.Contracts;

namespace zasz.me.Areas.Pro.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ISearchService _Search;

        public HomeController(ISearchService Search)
        {
            _Search = Search;
        }

        [DefaultAction]
        public ActionResult Show()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ViewResult Search(string Query)
        {
            _Search.Search(Query);
            return View();
        }
    }
}
