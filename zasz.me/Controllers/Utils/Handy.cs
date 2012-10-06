using System;
using System.Runtime.Caching;
using System.Web.Mvc;
using Elmah;

namespace zasz.me.Controllers.Utils
{
    public static class Handy
    {
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