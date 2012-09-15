using System.Collections.Generic;
using System.Text;
using System.Web.Mvc;
using System.Web.WebPages;
using zasz.me.Models;

namespace zasz.me.ViewModels
{
    public class PostListViewModel
    {
        private string pagingHtml;
        public List<Post> Posts { get; set; }
        public int NumberOfPages { get; set; }
        public int DescriptionLength { get; set; }
        public string WhatIsListed { get; set; }

        public MvcHtmlString GetPagingHtml(string requestPath)
        {
            if (string.IsNullOrEmpty(pagingHtml)) pagingHtml = GeneratePagingHtml(requestPath);
            return new MvcHtmlString(pagingHtml);
        }

        public string GeneratePagingHtml(string requestPath)
        {
            var splitPath = requestPath.Split(new[] {'/'});
            var lastSplit = splitPath[splitPath.Length - 1];
            var pagePath = requestPath + "/";
            var previousPath = "";
            var currentPage = 1;
            var nextPath = pagePath + "2";
            var previousEnabled = false;
            var nextEnabled = NumberOfPages > 1;
            if (lastSplit.Is<int>())
            {
                pagePath = requestPath.Substring(0, requestPath.Length - lastSplit.Length);
                currentPage = int.Parse(lastSplit);
                nextEnabled = currentPage < NumberOfPages;
                previousEnabled = currentPage > 1;
                previousPath = pagePath + (currentPage - 1);
                nextPath = pagePath + (currentPage + 1);
            }
            var b = new StringBuilder();
            if (NumberOfPages > 1)
            {
                b.Append("<div class='Paging'>");
                if (previousEnabled)
                    b.AppendFormat("<a href='{0}'>Previous</a>", previousPath);
                else
                    b.Append("<span class='DisabledPrevNext'>Previous</span>");
                for (var I = 1; I <= NumberOfPages; I++)
                {
                    if (I == currentPage)
                        b.AppendFormat("<span class='Current'>{0}</span>", I);
                    else
                        b.AppendFormat("<a href='{0}'>{1}</a>", pagePath + I, I);
                }
                if (nextEnabled)
                    b.AppendFormat("<a href='{0}'>Next</a>", nextPath);
                else
                    b.Append("<span class='DisabledPrevNext'>Next</span>");
                b.Append("</div>");
            }
            return b.ToString();
        }
    }
}