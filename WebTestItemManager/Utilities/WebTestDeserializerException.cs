using System;
using System.Collections.Generic;
using System.Text;

namespace WebTestItemManager
{
    public class WebTestDeserializerException : Exception
    {
        public WebTestDeserializerException() { }

        public WebTestDeserializerException(string message) : base(message) { }

        public WebTestDeserializerException(string message, Exception inner) : base(message, inner) { }
    }
}
