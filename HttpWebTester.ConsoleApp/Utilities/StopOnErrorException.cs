using System;
using System.Collections.Generic;
using System.Text;

namespace WebTestExecutionEngine
{
    public class StopOnErrorException : Exception
    {
        public StopOnErrorException() { }

        public StopOnErrorException(string message) : base(message) { }

        public StopOnErrorException(string message, Exception inner) : base(message, inner) { }
    }
}
