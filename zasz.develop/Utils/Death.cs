using System;

namespace zasz.develop.Utils
{
    internal class Death : Exception
    {
        public Death(string message) : base(message)
        {
        }
    }
}