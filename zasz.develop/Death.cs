using System;

namespace zasz.develop
{
    class Death : Exception
    {
        public Death(string message) : base(message)
        {
        }
    }
}
