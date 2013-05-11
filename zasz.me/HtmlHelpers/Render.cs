namespace zasz.me.HtmlHelpers
{
    using System.Text;
    using System.Web.Mvc;
    using System.Web.WebPages;

    public static class Render
    {
        public static MvcHtmlString Facebook(this HtmlHelper helper)
        {
            return new MvcHtmlString(@"
 <div id='fb-root'></div>
    <script> (function(d, s, id) {
    var js, fjs = d.getElementsByTagName(s)[0];
    if (d.getElementById(id)) return;
    js = d.createElement(s);
    js.id = id;
    js.src = '//connect.facebook.net/en_US/all.js#xfbml=1';
    fjs.parentNode.insertBefore(js, fjs);
}(document, 'script', 'facebook-jssdk')); </script>
");
        }

        public static MvcHtmlString FacebookLike(this HtmlHelper helper, string link)
        {
            return new MvcHtmlString(@"
    <div class='fb-like' data-href='@link' data-layout='button_count' data-send='true' data-width='290' data-show-faces='true' data-colorscheme='dark' data-font='trebuchet ms'></div>
");
        }

        public static MvcHtmlString Flair(this HtmlHelper helper)
        {
            return new MvcHtmlString(@"<a href='http://stackoverflow.com/users/626084/zasz'>
        @*?theme=clean or ?theme=dark or ?theme=hotdog*@
        <img src='http://stackoverflow.com/users/flair/626084.png?theme=dark' width='208' height='58' 
             alt='Profile for Zasz at Stack Overflow, Q&A for professional and enthusiast programmers' 
             title='Profile for Zasz at Stack Overflow, Q&A for professional and enthusiast programmers'>
    </a>");
        }

        public static MvcHtmlString Skype(this HtmlHelper helper, UrlHelper url)
        {
            return
                new MvcHtmlString(
                    @"<a href='skype:tc.zasz?call'><img src='@url.Content('~/Content/Images/skype.png')' style='border: none;' title='To avoid spam, this is an image. You cannot select or copy.' alt='Skype T Chandirasekar'/></a>");
        }

        public static MvcHtmlString Paging(this HtmlHelper helper, long numberOfPages)
        {
            if (numberOfPages <= 1)
            {
                return new MvcHtmlString(string.Empty);
            }

            var Request = helper.ViewContext.HttpContext.Request;
            var splitPath = Request.Path.Split(new[] { '/' });
            var lastSplit = splitPath[splitPath.Length - 1];
            var pagePath = Request.Path + "/";
            var previousPath = string.Empty;
            var currentPage = 1;
            var nextPath = pagePath + "2";
            var previousEnabled = false;
            var nextEnabled = numberOfPages > 1;
            if (lastSplit.Is<int>())
            {
                pagePath = Request.Path.Substring(0, Request.Path.Length - lastSplit.Length);
                currentPage = int.Parse(lastSplit);
                nextEnabled = currentPage < numberOfPages;
                previousEnabled = currentPage > 1;
                previousPath = pagePath + (currentPage - 1);
                nextPath = pagePath + (currentPage + 1);
            }

            var prevSection = previousEnabled ? string.Format("<a href='{0}'>Previous</a>", previousPath) : "<span class='DisabledPrevNext'>Previous</span>";
            var nextSection = nextEnabled ? string.Format("<a href='{0}'>Next</a>", nextPath) : "<span class='DisabledPrevNext'>Next</span>";
            var pagesSection = new StringBuilder();
            for (var i = 1; i <= numberOfPages; i++)
            {
                if (i == currentPage)
                {
                    pagesSection.AppendFormat("<span class='Current'>{0}</span>", i);
                }
                else
                {
                    pagesSection.AppendFormat("<a href='{0}'>{1}</a>", pagePath + i, i);
                }
            }

            return new MvcHtmlString(string.Format("<div class='Paging'> {0} {1} {2} </div>", prevSection, pagesSection, nextSection));
        }

        public static MvcHtmlString Tweet(this HtmlHelper helper, string link, string title)
        {
            return
                new MvcHtmlString(
                    @"<div style='margin-left: 20px'><a href='https://twitter.com/share' class='twitter-share-button' data-url='@link' data-text='@title'>Tweet</a></div>");
        }

        public static MvcHtmlString Twitter(this HtmlHelper helper)
        {
            return new MvcHtmlString(@"

    <script> !function(d, s, id) {
    var js, fjs = d.getElementsByTagName(s)[0];
    if (!d.getElementById(id)) {
        js = d.createElement(s);
        js.id = id;
        js.src = '//platform.twitter.com/widgets.js';
        fjs.parentNode.insertBefore(js, fjs);
}
}(document, 'script', 'twitter-wjs'); </script>");
        }
    }
}