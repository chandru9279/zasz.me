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

        public string MyStackOverflowAnswers(int pageNumber)
        {
                
            var extra = new Dictionary<string, string>();
            extra.Add("sort", "votes");
            extra.Add("page", pageNumber.ToString());
            return Compose(myPath + "/answers", extra);
        }

        public string StackOverflowQuestion(string whichQuestions)
        {
            return Compose(string.Format("questions/{0}", whichQuestions));
        }

        public string MyStackOverflowQuestions(int pageNumber)
        {
            var extra = new Dictionary<string, string>();
            extra.Add("sort", "votes");
            extra.Add("page", pageNumber.ToString()); 
            return Compose(myPath + "/questions", extra);
        }

        private static string Compose(string apiPath, Dictionary<string,string> extra = null)
        {
            extra = extra ?? new Dictionary<string, string>();
            var list = extra.Select(x => x.Key + "=" + x.Value).ToList();
            list.Add(apikey);
            return baseUrl + apiPath + soSite + string.Join("&", list);
        }
    }
}