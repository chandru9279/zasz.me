using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Web.Mvc;
using Newtonsoft.Json.Linq;
using zasz.me.Integration.MVC;
using zasz.me.Models;

namespace zasz.me.Controllers
{
    public class PortfolioController : BaseController
    {
        private StackUrls stackUrls;

        public PortfolioController()
        {
            stackUrls = new StackUrls();
        }

        [DefaultAction]
        public ActionResult All()
        {
            return View();
        }

        // http://stackapps.com/apps/oauth/view/688
        public ViewResult StackExchange()
        {
            var jsonAnswers = WebRequest.Create(stackUrls.MySoAnswers).GetResponse();
            var answers = JObject.Parse(ExtractJsonResponse(jsonAnswers));
            var questionIds = answers["items"].Select(x => (int)x["question_id"]).ToList();
            return View(questionIds);
        }

        private static string ExtractJsonResponse(WebResponse response)
        {
            string json;
            using (var outStream = new MemoryStream())
            using (var zipStream = new GZipStream(response.GetResponseStream(),
                CompressionMode.Decompress))
            {
                zipStream.CopyTo(outStream);
                outStream.Seek(0, SeekOrigin.Begin);
                using (var reader = new StreamReader(outStream, Encoding.UTF8))
                {
                    json = reader.ReadToEnd();
                }
            }
            return json;
        }
    }
}