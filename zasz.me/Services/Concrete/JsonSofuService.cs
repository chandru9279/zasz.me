using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using Newtonsoft.Json.Linq;
using zasz.me.Services.Contracts;

namespace zasz.me.Services.Concrete
{
    public class JsonSofuService : ISofuService
    {
        private readonly StackUrls urls;

        public JsonSofuService()
        {
            urls = new StackUrls();
        }

        public List<int> QuestionsAnswered()
        {
            var answers = Get(urls.MySoAnswers);
            var questionIds = answers["items"].Select(x => (int) x["question_id"]).ToList();
            return questionIds;
        }

        public Dictionary<int, string> QuestionTitles(List<int> questionIds)
        {
            var questions = Get(urls.SoQuestion(string.Join(";", questionIds)));
            var questionTitles = questions["items"].ToDictionary(x => (int)x["question_id"], x => (string)x["title"]);
            return questionTitles;
        }

        private static JObject Get(string url)
        {
            string json;
            var webRequest = WebRequest.Create(url);
            var response = webRequest.GetResponse();

            using (var outStream = new MemoryStream())
            using (var zipStream = new GZipStream(response.GetResponseStream(), CompressionMode.Decompress))
            {
                zipStream.CopyTo(outStream);
                outStream.Seek(0, SeekOrigin.Begin);
                using (var reader = new StreamReader(outStream, Encoding.UTF8))
                {
                    json = reader.ReadToEnd();
                }
            }
            return JObject.Parse(json);
        }
    }
}