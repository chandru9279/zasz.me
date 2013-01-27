using System.Web.Mvc;
using zasz.me.Integration.MVC;
using zasz.me.Services.Contracts;

namespace zasz.me.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ISearchService search;

        public HomeController(ISearchService service)
        {
            search = service;
        }

        [DefaultAction]
        public ViewResult About()
        {
            return View();
        }

        public ActionResult Favicon()
        {
            return new FilePathResult("~/Content/favicon.png", "image/png");
        }

        public ActionResult ToBlog()
        {
            return RedirectToAction("List", "Blog");
        }

        public ViewResult Search(string term)
        {
            var searchResults = search.Search(term);
            searchResults.Query = term;
            return View(searchResults);
        }

        public ContentResult Autocomplete(string term)
        {
            return Content(search.AutoComplete(term), "application/json");
        }
    }
}