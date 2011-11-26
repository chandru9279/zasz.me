using System;
using System.Web.Mvc;
using zasz.me.Integration.MVC;
using zasz.me.Services.Contracts;

namespace zasz.me.Areas.Pro.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ISearchService _Search;

        public HomeController(ISearchService Service)
        {
            _Search = Service;
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

        public ViewResult Search(string Search)
        {
            var SearchResults = _Search.Search(Search);
            SearchResults.Query = Search;
            return View(SearchResults);
        }

        public JsonResult Autocomplete([Bind(Prefix = "term")]string Input)
        {
            var Suggestions = _Search.AutoComplete(Input);
            var StartIndex = Suggestions.IndexOf('[');
            var EndIndex = Suggestions.IndexOf(']');
            var List = Suggestions.Substring(StartIndex + 1, EndIndex - StartIndex);
            var Send = new string[0];
            if (List.Length > 0)
            {
                var Strings = List.Split(new []{'\"'}, StringSplitOptions.RemoveEmptyEntries);
                Send = new string[Strings.Length/2];
                for (int I = 0; I < Strings.Length/2; I++)
                    Send[I] = Strings[I*2];
            }
            return Json(Send, JsonRequestBehavior.AllowGet);
        }
    }
}
