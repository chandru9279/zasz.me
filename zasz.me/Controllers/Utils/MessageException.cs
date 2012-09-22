using System;

namespace zasz.me.Controllers.Utils
{
    public class MessageException : Exception
    {
        public MessageException(string message) : base(message)
        {
        }

        public MessageException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}