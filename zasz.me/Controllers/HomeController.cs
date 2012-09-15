using System;
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
        public ViewResult Show()
        {
            return View();
        }

        public ViewResult About()
        {
            return View();
        }

        public ViewResult Search(string term)
        {
            var searchResults = search.Search(term);
            searchResults.Query = term;
            return View(searchResults);
        }

        public JsonResult Autocomplete(string term)
        {
            var suggestions = search.AutoComplete(term);
            var startIndex = suggestions.IndexOf('[');
            var endIndex = suggestions.IndexOf(']');
            var list = suggestions.Substring(startIndex + 1, endIndex - startIndex);
            var send = new string[0];
            if (list.Length > 0)
            {
                var strings = list.Split(new[] {'\"'}, StringSplitOptions.RemoveEmptyEntries);
                send = new string[strings.Length/2];
                for (var I = 0; I < strings.Length/2; I++)
                    send[I] = strings[I*2];
            }
            return Json(send, JsonRequestBehavior.AllowGet);
        }
    }
}