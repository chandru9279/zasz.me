using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using Newtonsoft.Json.Linq;
using zasz.me.Models;
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

        #region ISofuService Members

        public void PopulateTitles(List<SoAnswer> soAnswers)
        {
            var questions = Get(urls.SoQuestion(string.Join(";", soAnswers.Select(x => x.QuestionId))));
            var questionTitles = questions["items"].ToDictionary(x => (int) x["question_id"], x => (string) x["title"]);
            soAnswers.ForEach(x => x.QuestionTitle = questionTitles[x.QuestionId]);
        }

        #endregion

        public Pair<bool, List<SoAnswer>> QuestionsAnswered(int page)
        {
            var answers = Get(urls.MySoAnswers(page));
            var sort = ((page - 1) * 30) + 1;
            var soAnswers = answers["items"].Select(x => new SoAnswer
                                                             {
                                                                 Sort = sort++,
                                                                 QuestionId = (int) x["question_id"],
                                                                 AnswerId = (int) x["answer_id"]
                                                             }).ToList();
            var more = (bool)answers["has_more"];
            return new Pair<bool, List<SoAnswer>>(more, soAnswers);
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