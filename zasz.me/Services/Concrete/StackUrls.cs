using System.Collections.Generic;
using System.Linq;

namespace zasz.me.Services.Concrete
{
    // App URL : http://stackapps.com/apps/oauth/view/688
    public class StackUrls
    {
        private const string apikey = "key=usSGUdqhSFinjmEGnQYRCg((";
        private const string baseUrl = "http://api.stackexchange.com/";
        private const string soSite = "?site=stackoverflow&";
        private const string myPath = "users/626084";

        public StackUrls()
        {
            ExtraParams = new Dictionary<string, string>();
        }

        public string MySoAnswers
        {
            get { return JoinSo(myPath + "/answers"); }
        }

        public string SoQuestion(string whichQuestions)
        {
            return JoinSo(string.Format("questions/{0}", whichQuestions));
        }

        public string MySoQuestions
        {
            get { return JoinSo(myPath + "/questions"); }
        }

        public Dictionary<string, string> ExtraParams { get; set; }

        private string JoinSo(string apiPath)
        {
            var list = ExtraParams.Select(x => x.Key + "=" + x.Value).ToList();
            list.Add(apikey);
            return baseUrl + apiPath + soSite + string.Join("&", list);
        }
    }
}