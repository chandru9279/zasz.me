using System.Collections.Generic;
using System.Text;
using System.Web.Mvc;
using System.Web.WebPages;
using zasz.me.Areas.Shared.Models;

namespace zasz.me.Areas.Shared.ViewModels
{
    public class PostListModel
    {
        private string _PagingHtml;
        public List<Post> Posts { get; set; }
        public int NumberOfPages { get; set; }
        public int DescriptionLength { get; set; }
        public string WhatIsListed { get; set; }

        public MvcHtmlString GetPagingHtml(string RequestPath)
        {
            if (string.IsNullOrEmpty(_PagingHtml)) _PagingHtml = GeneratePagingHtml(RequestPath);
            return new MvcHtmlString(_PagingHtml);
        }

        public string GeneratePagingHtml(string RequestPath)
        {
            var SplitPath = RequestPath.Split(new[] { '/' });
            var LastSplit = SplitPath[SplitPath.Length - 1];
            var PagePath = RequestPath + "/";
            var PreviousPath = "";
            var CurrentPage = 1;
            var NextPath = PagePath + "2";
            var PreviousEnabled = false;
            var NextEnabled = NumberOfPages > 1;
            if (LastSplit.Is<int>())
            {
                PagePath = RequestPath.Substring(0, RequestPath.Length - LastSplit.Length);
                CurrentPage = int.Parse(LastSplit);
                NextEnabled = CurrentPage < NumberOfPages;
                PreviousEnabled = CurrentPage > 1;
                PreviousPath = PagePath + (CurrentPage - 1);
                NextPath = PagePath + (CurrentPage + 1);
            }
            var B = new StringBuilder();
            if (NumberOfPages > 1)
            {
                B.Append("<div class='Paging'>");
                if (PreviousEnabled)
                    B.AppendFormat("<a href='{0}'>Previous</a>", PreviousPath);
                else
                    B.Append("<span class='DisabledPrevNext'>Previous</span>");
                for (var I = 1; I <= NumberOfPages; I++)
                {
                    if (I == CurrentPage)
                        B.AppendFormat("<span class='Current'>{0}</span>", I);
                    else
                        B.AppendFormat("<a href='{0}'>{1}</a>", PagePath + I, I);
                }
                if (NextEnabled)
                    B.AppendFormat("<a href='{0}'>Next</a>", NextPath);
                else
                    B.Append("<span class='DisabledPrevNext'>Next</span>");
                B.Append("</div>");
            }
            return B.ToString();
        }
    }
}