using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Web.Mvc;
using Elmah;

namespace zasz.me.Controllers.Utils
{
    public static class Handy
    {
        public static List<string> Shred(string wordList)
        {
            return String.IsNullOrEmpty(wordList)
                       ? new List<string>()
                       : wordList.Split(Constants.Shredders, StringSplitOptions.RemoveEmptyEntries).ToList();
        }

        public static void Log(string message)
        {
            ErrorSignal.FromCurrentContext().Raise(new MessageException(message));
        }

        public static void Log(string message, Exception e)
        {
            ErrorSignal.FromCurrentContext().Raise(new MessageException(message, e));
        }

        /* This mad method will expire all output cache, i.e., every cached action is invalidated.
         * http://stackoverflow.com/questions/5326230/mvc3-outputcache-removeoutputcacheitem-renderaction*/
        public static void InvalidateOutputCache()
        {
            OutputCacheAttribute.ChildActionCache = new MemoryCache("NewDefault");
        }
    }
}