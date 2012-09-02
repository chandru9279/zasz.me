using System;

namespace zasz.develop.Utils
{
    class Death : Exception
    {
        public Death(string message) : base(message)
        {
        }
    }
}
